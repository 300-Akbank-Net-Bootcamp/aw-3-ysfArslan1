using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IMediator mediator;
    public AddressesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    // Address Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAllAddressQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    [HttpGet("/GetAddressByParameterQuery")]
    public async Task<IActionResult> GetAddressByParameterQuery([FromQuery] int CustomerNumber, string Address1, string City)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAddressByParameterQuery(CustomerNumber, Address1, City);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address nesnesini database eklemek için kullanýlýr
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAddressRequest Address)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new CreateAddressCommand(Address);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki id degeri gönderilen nesneyi düzenlemek için kullanýlýr 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAddressRequest Address)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new UpdateAddressCommand(id, Address);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki id degeri gönderilen nesneyi silmek için kullanýlýr 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new DeleteAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}