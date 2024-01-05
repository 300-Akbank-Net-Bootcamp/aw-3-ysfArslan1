using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Threading;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Data;
using Vb.Data.Entity;
using Vb.Schema;

namespace Vb.Business.Command;

public class AccountCommandHandler :
    IRequestHandler<CreateAccountCommand, IActionResult>,
    IRequestHandler<UpdateAccountCommand, IActionResult>,
    IRequestHandler<DeleteAccountCommand, IActionResult>

{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public AccountCommandHandler(VbDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var checkIdentity = await dbContext.Customers.Where(x => x.CustomerNumber == request.Model.CustomerNumber)
            .FirstOrDefaultAsync(cancellationToken);
            
            if (checkIdentity == null )
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Customer not found"
                };
                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            var entity = mapper.Map<CreateAccountRequest, Account>(request.Model);
            entity.AccountNumber = await generateAccountNumber();
            entity.IBAN = generateIBAN(); // bun bk

            var entityResult = await dbContext.Accounts.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Account, AccountResponse>(entity);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 201, // 201 Created durumu
                Message = "Account created successfully",
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
    public async Task<IActionResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        
        try
        {
            var fromdb = await dbContext.Accounts.Where(x => x.AccountNumber == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Account not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            fromdb.Balance = request.Model.Balance;
            fromdb.Name = request.Model.Name;
            fromdb.UpdateUserId = request.Model.UpdateUserId;
            fromdb.UpdateDate = DateTime.Now;

            dbContext.Accounts.Update(fromdb);//yeni
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Account, AccountResponse>(fromdb);

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

    public async Task<IActionResult> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var fromdb = await dbContext.Accounts.Where(x => x.AccountNumber == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Account not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }


            fromdb.IsActive = false;

            dbContext.Accounts.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Account deleted successfully",
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

    public async Task<int> generateAccountNumber()
    {
        int AccountNumber = new Random().Next(1000000, 9999999);
        var checkAccount = await dbContext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefaultAsync();
        
        if (checkAccount != null)
        {
            AccountNumber = new Random().Next(1000000, 9999999);
            checkAccount = await dbContext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefaultAsync();
        }
        return AccountNumber;
    }
    public string generateIBAN()
    {
        string IBAN =   new Random().Next(1000000, 9999999).ToString();

        return IBAN;
    }
}