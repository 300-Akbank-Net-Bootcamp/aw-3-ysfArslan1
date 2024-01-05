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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var operation = new GetAllCustomerQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{CustomerNumber}")]
    public async Task<IActionResult> Get(int CustomerNumber)
    {
        var operation = new GetCustomerByIdQuery(CustomerNumber);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("/GetCustomerByParameterQuery")]
    public async Task<IActionResult> GetCustomerByParameterQuery([FromQuery] string IdentityNumber, string FirstName, string LastName)
    {
        var operation = new GetCustomerByParameterQuery(IdentityNumber, FirstName, LastName);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerRequest customer)
    {
        var operation = new CreateCustomerCommand(customer);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{CustomerNumber}")]
    public async Task<IActionResult> Put(int CustomerNumber, [FromBody] UpdateCustomerRequest customer)
    {
        var operation = new UpdateCustomerCommand(CustomerNumber, customer);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{CustomerNumber}")]
    public async Task<IActionResult> Delete(int CustomerNumber)
    {
        var operation = new DeleteCustomerCommand(CustomerNumber);
        var result = await mediator.Send(operation);
        return result;
    }
}