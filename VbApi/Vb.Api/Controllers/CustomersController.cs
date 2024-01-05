using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator mediator;
    public CustomersController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    // Customer Tablosundaki nesnelerin tamam�n� almak i�in kullan�l�r 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAllCustomerQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki id degeri g�nderilen nesneyi almak i�in kullan�l�r 
    [HttpGet("{CustomerNumber}")]
    public async Task<IActionResult> Get(int CustomerNumber)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetCustomerByIdQuery(CustomerNumber);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki istenilen degerleri g�nderilen nesneyi almak i�in kullan�l�r
    [HttpGet("/GetCustomerByParameterQuery")]
    public async Task<IActionResult> GetCustomerByParameterQuery([FromQuery] string IdentityNumber, string FirstName, string LastName)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetCustomerByParameterQuery(IdentityNumber, FirstName, LastName);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer nesnesini database eklemek i�in kullan�l�r
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerRequest customer)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new CreateCustomerCommand(customer);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki id degeri g�nderilen nesneyi d�zenlemek i�in kullan�l�r 
    [HttpPut("{CustomerNumber}")]
    public async Task<IActionResult> Put(int CustomerNumber, [FromBody] UpdateCustomerRequest customer)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new UpdateCustomerCommand(CustomerNumber, customer);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki id degeri g�nderilen nesneyi silmek i�in kullan�l�r 
    [HttpDelete("{CustomerNumber}")]
    public async Task<IActionResult> Delete(int CustomerNumber)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new DeleteCustomerCommand(CustomerNumber);
        var result = await mediator.Send(operation);
        return result;
    }
}