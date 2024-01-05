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

public class EftTransactionCommandHandler :
    IRequestHandler<CreateEftTransactionCommand, IActionResult>,
    IRequestHandler<UpdateEftTransactionCommand, IActionResult>,
    IRequestHandler<DeleteEftTransactionCommand, IActionResult>

{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public EftTransactionCommandHandler(VbDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    // EftTransaction nesnesini �retmek i�in kullan�l�r
    public async Task<IActionResult> Handle(CreateEftTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Foreign Key kontrolu yap�l�r
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
            var entity = mapper.Map<CreateEftTransactionRequest, EftTransaction>(request.Model);


            // database i�lemleri yap�l�yor
            var entityResult = await dbContext.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            // response mapper ile olu�turulur
            var mappedItem = mapper.Map<EftTransaction, EftTransactionResponse>(entity);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 201, 
                Message = "Account created successfully",
                Response = mappedItem 
            };

            return new ObjectResult(response) { StatusCode = 201 }; 
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

    // EftTransaction nesnesini d�zenlemek i�in kullan�l�r
    public async Task<IActionResult> Handle(UpdateEftTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // database de nesnenin kontrolu yap�l�r
            var fromdb = await dbContext.EftTransactions.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "EftTransaction not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 };     
            }
            fromdb.ReferenceNumber = request.Model.ReferenceNumber;
            fromdb.Amount = request.Model.Amount;
            fromdb.Description = request.Model.Description;
            fromdb.UpdateUserId = request.Model.UpdateUserId;
            fromdb.UpdateDate = DateTime.Now;

            // database i�lemleri yap�l�yor
            dbContext.EftTransactions.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            // response mapper ile olu�turulur
            var mappedItem = mapper.Map<EftTransaction, EftTransactionResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Account updated successfully",
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

            return new ObjectResult(response) { StatusCode = 500 }; // 500 Internal Server Error durumu
        }
    }


    // EftTransaction nesnesini silmek i�in kullan�l�r
    public async Task<IActionResult> Handle(DeleteEftTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // database de nesnenin kontrolu yap�l�r
            var fromdb = await dbContext.EftTransactions.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "EftTransaction not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }


            fromdb.IsActive = false;

            // database i�lemleri yap�l�yor
            dbContext.EftTransactions.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            // response mapper ile olu�turulur
            var mappedItem = mapper.Map<EftTransaction, EftTransactionResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Account deleted successfully",
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

            return new ObjectResult(response) { StatusCode = 500 }; // 500 Internal Server Error durumu
        }
    }
}