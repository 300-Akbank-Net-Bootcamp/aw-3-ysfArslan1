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

public class ContactQueryHandler :
    IRequestHandler<GetAllContactQuery, IActionResult>,
    IRequestHandler<GetContactByIdQuery, IActionResult>
{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public ContactQueryHandler(VbDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Handle(GetAllContactQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var list = await dbContext.Contacts.ToListAsync(cancellationToken);
            var mappedList = mapper.Map<List<Contact>, List<ContactResponse>>(list);

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
    public async Task<IActionResult> Handle(GetContactByIdQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var item = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var mappedItem = mapper.Map<Contact, ContactResponse>(item);

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
    public async Task<IActionResult> Handle(GetContactByParameterQuery request,
        CancellationToken cancellationToken)
    {
       
        try
        {
            var item = await dbContext.Contacts.Where(x => x.CustomerNumber == request.CustomerNumber)
                .Where(x => x.ContactType == request.ContactType).Where(x => x.Information == request.Information).FirstOrDefaultAsync(cancellationToken);

            var mappedItem = mapper.Map<Contact, ContactResponse>(item);

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