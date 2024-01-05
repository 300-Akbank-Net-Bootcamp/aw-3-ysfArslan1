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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var operation = new GetAllAddressQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var operation = new GetAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("/GetAddressByParameterQuery")]
    public async Task<IActionResult> GetAddressByParameterQuery([FromQuery] int CustomerNumber, string Address1, string City)
    {
        var operation = new GetAddressByParameterQuery(CustomerNumber, Address1, City);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAddressRequest Address)
    {
        var operation = new CreateAddressCommand(Address);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAddressRequest Address)
    {
        var operation = new UpdateAddressCommand(id, Address);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var operation = new DeleteAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}