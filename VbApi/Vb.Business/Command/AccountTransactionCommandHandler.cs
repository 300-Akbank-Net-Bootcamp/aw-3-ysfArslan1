using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Data;
using Vb.Data.Entity;
using Vb.Schema;

namespace Vb.Business.Command;

public class AccountTransactionCommandHandler :
    IRequestHandler<CreateAccountTransactionCommand, IActionResult>,
    IRequestHandler<UpdateAccountTransactionCommand, IActionResult>,
    IRequestHandler<DeleteAccountTransactionCommand, IActionResult>

{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public AccountTransactionCommandHandler(VbDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Handle(CreateAccountTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var checkIdentity = await dbContext.Accounts.Where(x => x.AccountNumber == request.Model.AccountNumber)
            .FirstOrDefaultAsync(cancellationToken);
            if (checkIdentity == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Account not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            var entity = mapper.Map<CreateAccountTransactionRequest, AccountTransaction>(request.Model);
            

            var entityResult = await dbContext.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<AccountTransaction, AccountTransactionResponse>(entity);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 201, // 201 Created durumu
                Message = "AccountTransaction created successfully",
                Response = mappedItem // Yeni hesabýn detaylarý veya gerekli bilgiler
            };

            return new ObjectResult(response) { StatusCode = 201 }; // 201 Created durumu ile birlikte veri döndürülüyor
        }
        catch (Exception ex)
        {
            var response = new
            {
                StatusCode = 500,
                Message = $"Internal Server Error: {ex.Message}"
            };

            return new ObjectResult(response) { StatusCode = 500 }; // 500 Internal Server Error durumu
        }
    }

    public async Task<IActionResult> Handle(UpdateAccountTransactionCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var fromdb = await dbContext.AccountTransactions.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "AccountTransaction not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            fromdb.ReferenceNumber = request.Model.ReferenceNumber;
            fromdb.Amount = request.Model.Amount;
            fromdb.Description = request.Model.Description;
            fromdb.TransferType = request.Model.TransferType;
            fromdb.UpdateUserId = request.Model.UpdateUserId;
            fromdb.UpdateDate = DateTime.Now;

            dbContext.AccountTransactions.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<AccountTransaction, AccountTransactionResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "AccountTransaction updated successfully",
                Response = mappedItem
            };

            return new ObjectResult(response) { StatusCode = 200 }; 
        }
        catch (Exception ex)
        {
            var response = new
            {
                StatusCode = 500,
                Message = $"Internal Server Error: {ex.Message}"
            };

            return new ObjectResult(response) { StatusCode = 500 }; 
        }
    }

    public async Task<IActionResult> Handle(DeleteAccountTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var fromdb = await dbContext.AccountTransactions.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "AccountTransaction not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }


            fromdb.IsActive = false;

            dbContext.AccountTransactions.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<AccountTransaction, AccountTransactionResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "AccountTransaction deleted successfully",
                Response = mappedItem 
            };

            return new ObjectResult(response) { StatusCode = 200 }; 
        }
        catch (Exception ex)
        {
            var response = new
            {
                StatusCode = 500,
                Message = $"Internal Server Error: {ex.Message}"
            };

            return new ObjectResult(response) { StatusCode = 500 }; 
        }
    }
}