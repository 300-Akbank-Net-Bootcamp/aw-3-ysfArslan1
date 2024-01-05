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

public class ContactCommandHandler :
    IRequestHandler<CreateContactCommand, IActionResult>,
    IRequestHandler<UpdateContactCommand, IActionResult>,
    IRequestHandler<DeleteContactCommand, IActionResult>

{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public ContactCommandHandler(VbDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    // Contact nesnesini üretmek için kullanýlýr
    public async Task<IActionResult> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Foreign Key kontrolu yapýlýr
            var checkIdentity = await dbContext.Customers.Where(x => x.CustomerNumber == request.Model.CustomerNumber)
            .FirstOrDefaultAsync(cancellationToken);
            if (checkIdentity == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Customer not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            var entity = mapper.Map<CreateContactRequest, Contact>(request.Model);
            // database iþlemleri yapýlýyor
            var entityResult = await dbContext.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            // response mapper ile oluþturulur
            var mappedItem = mapper.Map<Contact, ContactResponse>(entity);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 201, // 201 Created durumu
                Message = "Contact created successfully",
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
    // Contact nesnesini düzenlemek için kullanýlýr
    public async Task<IActionResult> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // database de nesnenin kontrolu yapýlýr
            var fromdb = await dbContext.Contacts.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Contact not found",
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            fromdb.ContactType = request.Model.ContactType;
            fromdb.Information = request.Model.Information;
            fromdb.IsDefault = request.Model.IsDefault;
            fromdb.UpdateUserId = request.Model.UpdateUserId;
            fromdb.UpdateDate = DateTime.Now;
            // database iþlemleri yapýlýyor
            dbContext.Contacts.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            // response mapper ile oluþturulur
            var mappedItem = mapper.Map<Contact, ContactResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Contact updated successfully",
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

    // Contact nesnesini silmek için kullanýlýr
    public async Task<IActionResult> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // database de nesnenin kontrolu yapýlýr
            var fromdb = await dbContext.Contacts.Where(x => x.Id== request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Contact not found",
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }


            fromdb.IsActive = false;
            // database iþlemleri yapýlýyor
            dbContext.Contacts.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            // response mapper ile oluþturulur
            var mappedItem = mapper.Map<Contact, ContactResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200,
                Message = "Contact deleted successfully",
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