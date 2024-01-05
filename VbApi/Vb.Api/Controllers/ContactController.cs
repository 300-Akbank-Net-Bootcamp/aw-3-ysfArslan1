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

    // Contact Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAllContactQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetContactByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    [HttpGet("/GetContactByParameterQuery")]
    public async Task<IActionResult> GetContactByParameterQuery([FromQuery] int CustomerNumber, string ContactType, string Information)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetContactByParameterQuery(CustomerNumber, ContactType, Information);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact nesnesini database eklemek için kullanýlýr
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContactRequest Contact)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new CreateContactCommand(Contact);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki id degeri gönderilen nesneyi düzenlemek için kullanýlýr 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateContactRequest Contact)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new UpdateContactCommand(id, Contact);
        var result = await mediator.Send(operation);
        return result;
    }

    // Contact Tablosundaki id degeri gönderilen nesneyi silmek için kullanýlýr 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new DeleteContactCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}