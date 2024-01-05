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

public class AddressCommandHandler :
    IRequestHandler<CreateAddressCommand, IActionResult>,
    IRequestHandler<UpdateAddressCommand, IActionResult>,
    IRequestHandler<DeleteAddressCommand, IActionResult>

{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public AddressCommandHandler(VbDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<IActionResult> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var checkIdentity = await dbContext.Customers.Where(x => x.CustomerNumber == request.Model.CustomerNumber)
            .FirstOrDefaultAsync(cancellationToken);
            if (checkIdentity == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Customer not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            
            }
            var entity = mapper.Map<CreateAddressRequest, Address>(request.Model);

            var entityResult = await dbContext.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Address, AddressResponse>(entity);

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
    public async Task<IActionResult> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var fromdb = await dbContext.Addresses.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Address not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            fromdb.Address1 = request.Model.Address1;
            fromdb.Address2 = request.Model.Address2;
            fromdb.Country = request.Model.Country;
            fromdb.City = request.Model.City;
            fromdb.County = request.Model.County;
            fromdb.PostalCode = request.Model.PostalCode;
            fromdb.IsDefault = request.Model.IsDefault;
            fromdb.UpdateUserId = request.Model.UpdateUserId;
            fromdb.UpdateDate = DateTime.Now;

            dbContext.Addresses.Update(fromdb);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Address, AddressResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Address updated successfully",
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

    public async Task<IActionResult> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var fromdb = await dbContext.Addresses.Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb != null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Address not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }


            fromdb.IsActive = false;

            dbContext.Addresses.Update(fromdb);//yeni
            await dbContext.SaveChangesAsync(cancellationToken);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200,
                Message = "Address deleted successfully",
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