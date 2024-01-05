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

public class CustomerCommandHandler :
    IRequestHandler<CreateCustomerCommand, IActionResult>,
    IRequestHandler<UpdateCustomerCommand, IActionResult>,
    IRequestHandler<DeleteCustomerCommand, IActionResult>

{
    private readonly VbDbContext dbContext;
    private readonly IMapper mapper;

    public CustomerCommandHandler(VbDbContext dbContext,IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }


    public async Task<IActionResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var checkIdentity = await dbContext.Customers.Where(x => x.IdentityNumber == request.Model.IdentityNumber)
            .FirstOrDefaultAsync(cancellationToken);
            if (checkIdentity != null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Bad Request"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }
            var entity = mapper.Map<CreateCustomerRequest, Customer>(request.Model);
            entity.Accounts[0].IBAN = generateIBAN();
            entity.Accounts[0].AccountNumber = generateAccountNumber();
            entity.CustomerNumber = generateCustomerNumber();
            var entityResult = await dbContext.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Customer, CustomerResponse>(entity);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 201, // 201 Created durumu
                Message = "Customer created successfully",
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

    public async Task<IActionResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var fromdb = await dbContext.Customers.Where(x => x.CustomerNumber == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Customer not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; 
            }
            fromdb.FirstName = request.Model.FirstName;
            fromdb.LastName = request.Model.LastName;
            fromdb.DateOfBirth = request.Model.DateOfBirth;
            fromdb.UpdateUserId = request.Model.UpdateUserId;
            fromdb.UpdateDate = DateTime.Now;

            dbContext.Customers.Update(fromdb);//yeni
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Customer, CustomerResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Customer updated successfully",
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

    public async Task<IActionResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var fromdb = await dbContext.Customers.Where(x => x.CustomerNumber == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if (fromdb == null)
            {
                var responseNF = new
                {
                    StatusCode = 404,
                    Message = "Customer not found"
                };

                return new ObjectResult(responseNF) { StatusCode = 404 }; // 404 Not Found durumu            }
            }


            fromdb.IsActive = false;

            dbContext.Customers.Update(fromdb);//yeni
            await dbContext.SaveChangesAsync(cancellationToken);
            var mappedItem = mapper.Map<Customer, CustomerResponse>(fromdb);

            var response = new
            {
                ServerDate = DateTime.UtcNow,
                ReferenceNo = Guid.NewGuid(),
                Success = true,
                StatusCode = 200, 
                Message = "Customer deleted successfully",
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
    public string generateIBAN()
    {
        string IBAN = new Random().Next(1000000, 9999999).ToString();

        return IBAN;
    }
    public int generateAccountNumber()
    {
        int number = new Random().Next(0, 9999999);
        var item = dbContext.Accounts.FirstOrDefault(x => x.AccountNumber == number);
        while (item != null)
        {
            item = dbContext.Accounts.FirstOrDefault(x => x.AccountNumber == number);
        }

        return number;
    }

    public int generateCustomerNumber()
    {
        int number = new Random().Next(0, 9999999);
        var item = dbContext.Customers.FirstOrDefault(x => x.CustomerNumber == number);
        while (item != null)
        {
            item = dbContext.Customers.FirstOrDefault(x => x.CustomerNumber == number);
        }

        return number;
    }
}