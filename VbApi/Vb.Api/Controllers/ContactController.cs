using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IMediator mediator;
    public ContactController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    // Contact Tablosundaki nesnelerin tamam�n� almak i�in kullan�l�r 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAllContactQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki id degeri g�nderilen nesneyi almak i�in kullan�l�r 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetContactByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki istenilen degerleri g�nderilen nesneyi almak i�in kullan�l�r
    [HttpGet("/GetContactByParameterQuery")]
    public async Task<IActionResult> GetContactByParameterQuery([FromQuery] int CustomerNumber, string ContactType, string Information)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetContactByParameterQuery(CustomerNumber, ContactType, Information);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact nesnesini database eklemek i�in kullan�l�r
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContactRequest Contact)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new CreateContactCommand(Contact);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki id degeri g�nderilen nesneyi d�zenlemek i�in kullan�l�r 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateContactRequest Contact)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new UpdateContactCommand(id, Contact);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki id degeri g�nderilen nesneyi silmek i�in kullan�l�r 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new DeleteContactCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}