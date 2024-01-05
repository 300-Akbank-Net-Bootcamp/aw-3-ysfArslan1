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

    // Address Tablosundaki nesnelerin tamam�n� almak i�in kullan�l�r 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAllAddressQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki id degeri g�nderilen nesneyi almak i�in kullan�l�r 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki istenilen degerleri g�nderilen nesneyi almak i�in kullan�l�r
    [HttpGet("/GetAddressByParameterQuery")]
    public async Task<IActionResult> GetAddressByParameterQuery([FromQuery] int CustomerNumber, string Address1, string City)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAddressByParameterQuery(CustomerNumber, Address1, City);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address nesnesini database eklemek i�in kullan�l�r
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAddressRequest Address)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new CreateAddressCommand(Address);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki id degeri g�nderilen nesneyi d�zenlemek i�in kullan�l�r 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAddressRequest Address)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new UpdateAddressCommand(id, Address);
        var result = await mediator.Send(operation);
        return result;
    }

    // Address Tablosundaki id degeri g�nderilen nesneyi silmek i�in kullan�l�r 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new DeleteAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}