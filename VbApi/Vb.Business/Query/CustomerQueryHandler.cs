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

public class CustomerQueryHandler :
    IRequestHandler<GetAllCustomerQuery, IActionResult>,
    IRequestHandler<GetCustomerByIdQuery, IActionResult>,
    IRequestHandler<GetCustomerByParameterQuery, IActionResult>
{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public CustomerQueryHandler(VbDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    // Customer Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    public async Task<IActionResult> Handle(GetAllCustomerQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var list = await dbContext.Customers.ToListAsync(cancellationToken);
            var mappedList = mapper.Map<List<Customer>, List<CustomerResponse>>(list);

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

    // Customer Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    public async Task<IActionResult> Handle(GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == request.Id, cancellationToken);

            var mappedItem = mapper.Map<Customer, CustomerResponse>(item);

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

    // Customer Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    public async Task<IActionResult> Handle(GetCustomerByParameterQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.Customers.Where(x => x.FirstName == request.FirstName)
                .Where(x => x.LastName == request.LastName).Where(x => x.IdentityNumber == request.IdentityNumber).FirstOrDefaultAsync(cancellationToken);

            var mappedItem = mapper.Map<Customer, CustomerResponse>(item);

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