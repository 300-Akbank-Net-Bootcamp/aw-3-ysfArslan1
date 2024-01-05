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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var operation = new GetAllContactQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var operation = new GetContactByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("/GetContactByParameterQuery")]
    public async Task<IActionResult> GetContactByParameterQuery([FromQuery] int CustomerNumber, string ContactType, string Information)
    {
        var operation = new GetContactByParameterQuery(CustomerNumber, ContactType, Information);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateContactRequest Contact)
    {
        var operation = new CreateContactCommand(Contact);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateContactRequest Contact)
    {
        var operation = new UpdateContactCommand(id, Contact);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var operation = new DeleteContactCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}