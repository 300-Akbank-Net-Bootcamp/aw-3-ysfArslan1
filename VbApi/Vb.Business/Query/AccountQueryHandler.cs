using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Data;
using Vb.Data.Entity;
using Vb.Schema;

namespace Vb.Business.Query;

public class AccountQueryHandler :
    IRequestHandler<GetAllAccountQuery,IActionResult>,
    IRequestHandler<GetAccountByIdQuery,IActionResult>,
    IRequestHandler<GetAccountByParameterQuery, IActionResult>
{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public AccountQueryHandler(VbDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    public async Task<IActionResult> Handle(GetAllAccountQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var list = await dbContext.Accounts.ToListAsync(cancellationToken);
            var mappedList = mapper.Map<List<Account>, List<AccountResponse>>(list);
            
            if (mappedList.Any())
            {
                var response = new
                {
                    ServerDate = DateTime.UtcNow,
                    ReferenceNo = Guid.NewGuid(),
                    Success = true,
                    StatusCode = 200,
                    Message = "Data retrieved successfully",
                    Response = mappedList
                };

                return new ObjectResult(response) { StatusCode = 200 }; // 200 OK durumu ile birlikte veri döndürülüyor
            }
            else
            {
                var response = new
                {
                    StatusCode = 404,
                    Message = "No data found"
                };

                return new ObjectResult(response) { StatusCode = 404 }; // 404 Not Found durumu
            }
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
    public async Task<IActionResult> Handle(GetAccountByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == request.Id, cancellationToken);

            var mappedItem = mapper.Map<Account, AccountResponse>(item);

            if (mappedItem != null)
            {
                var response = new
                {
                    ServerDate = DateTime.UtcNow,
                    ReferenceNo = Guid.NewGuid(),
                    Success = true,
                    StatusCode = 200,
                    Message = "Data retrieved successfully",
                    Response = mappedItem
                };

                return new ObjectResult(response) { StatusCode = 200 }; // 200 OK durumu ile birlikte veri döndürülüyor
            }
            else
            {
                var response = new
                {
                    StatusCode = 404,
                    Message = "No data found"
                };

                return new ObjectResult(response) { StatusCode = 404 }; // 404 Not Found durumu
            }
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
    public async Task<IActionResult> Handle(GetAccountByParameterQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.Accounts.Where(x => x.AccountNumber == request.AccountNumber)
                .Where(x => x.IBAN == request.IBAN).Where(x => x.Name == request.Name).FirstOrDefaultAsync(cancellationToken);

            var mappedItem = mapper.Map<Account, AccountResponse>(item);

            if (mappedItem != null)
            {
                var response = new
                {
                    ServerDate = DateTime.UtcNow,
                    ReferenceNo = Guid.NewGuid(),
                    Success = true,
                    StatusCode = 200,
                    Message = "Data retrieved successfully",
                    Response = mappedItem
                };

                return new ObjectResult(response) { StatusCode = 200 }; // 200 OK durumu ile birlikte veri döndürülüyor
            }
            else
            {
                var response = new
                {
                    StatusCode = 404,
                    Message = "No data found"
                };

                return new ObjectResult(response) { StatusCode = 404 }; // 404 Not Found durumu
            }
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