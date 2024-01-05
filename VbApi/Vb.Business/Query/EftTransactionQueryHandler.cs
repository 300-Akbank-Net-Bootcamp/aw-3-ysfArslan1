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

public class EftTransactionQueryHandler :
    IRequestHandler<GetAllEftTransactionQuery,IActionResult>,
    IRequestHandler<GetEftTransactionByIdQuery,IActionResult>
{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public EftTransactionQueryHandler(VbDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Handle(GetAllEftTransactionQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var list = await dbContext.EftTransactions.ToListAsync(cancellationToken);
            var mappedList = mapper.Map<List<EftTransaction>, List<EftTransactionResponse>>(list);

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
 
    public async Task<IActionResult> Handle(GetEftTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.EftTransactions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var mappedItem = mapper.Map<EftTransaction, EftTransactionResponse>(item);

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
    public async Task<IActionResult> Handle(GetEftTransactionByParameterQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.EftTransactions.Where(x => x.AccountNumber == request.AccountNumber)
                .Where(x => x.ReferenceNumber == request.ReferenceNumber).Where(x => x.SenderIban == request.SenderIban).FirstOrDefaultAsync(cancellationToken);

            var mappedItem = mapper.Map<EftTransaction, EftTransactionResponse>(item);

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