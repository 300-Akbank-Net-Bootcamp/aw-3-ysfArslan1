using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Data;
using Vb.Data.Entity;
using Vb.Schema;

namespace Vb.Business.Query;

public class AccountTransactionQueryHandler :
    IRequestHandler<GetAllAccountTransactionQuery, IActionResult>,
    IRequestHandler<GetAccountTransactionByIdQuery, IActionResult>
{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public AccountTransactionQueryHandler(VbDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    // AccountTransaction Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    public async Task<IActionResult> Handle(GetAllAccountTransactionQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var list = await dbContext.AccountTransactions.ToListAsync(cancellationToken);
            var mappedList = mapper.Map<List<AccountTransaction>, List<AccountTransactionResponse>>(list);

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
    // AccountTransaction Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    public async Task<IActionResult> Handle(GetAccountTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.AccountTransactions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var mappedItem = mapper.Map<AccountTransaction, AccountTransactionResponse>(item);

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

    // AccountTransaction Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    public async Task<IActionResult> Handle(GetAccountTransactionByParameterQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.AccountTransactions.Where(x => x.AccountNumber == request.AccountNumber)
                .Where(x => x.ReferenceNumber == request.ReferenceNumber).Where(x => x.Description == request.Description).FirstOrDefaultAsync(cancellationToken);
            var mappedItem = mapper.Map<AccountTransaction, AccountTransactionResponse>(item);
            if (item != null)
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