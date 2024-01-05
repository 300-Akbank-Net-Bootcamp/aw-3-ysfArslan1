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
    // Customer Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAllCustomerQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    [HttpGet("{CustomerNumber}")]
    public async Task<IActionResult> Get(int CustomerNumber)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetCustomerByIdQuery(CustomerNumber);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    [HttpGet("/GetCustomerByParameterQuery")]
    public async Task<IActionResult> GetCustomerByParameterQuery([FromQuery] string IdentityNumber, string FirstName, string LastName)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetCustomerByParameterQuery(IdentityNumber, FirstName, LastName);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer nesnesini database eklemek için kullanýlýr
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerRequest customer)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new CreateCustomerCommand(customer);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki id degeri gönderilen nesneyi düzenlemek için kullanýlýr 
    [HttpPut("{CustomerNumber}")]
    public async Task<IActionResult> Put(int CustomerNumber, [FromBody] UpdateCustomerRequest customer)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new UpdateCustomerCommand(CustomerNumber, customer);
        var result = await mediator.Send(operation);
        return result;
    }
    // Customer Tablosundaki id degeri gönderilen nesneyi silmek için kullanýlýr 
    [HttpDelete("{CustomerNumber}")]
    public async Task<IActionResult> Delete(int CustomerNumber)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new DeleteCustomerCommand(CustomerNumber);
        var result = await mediator.Send(operation);
        return result;
    }
}