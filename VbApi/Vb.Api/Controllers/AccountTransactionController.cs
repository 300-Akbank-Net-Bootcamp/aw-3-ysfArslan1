using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountTransactionController : ControllerBase
{
    private readonly IMediator mediator;
    public AccountTransactionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var operation = new GetAllAccountTransactionQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var operation = new GetAccountTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("/GetAccountTransactionByParameterQuery")]
    public async Task<IActionResult> GetAccountTransactionByParameterQuery([FromQuery] int AccountNumber, string ReferenceNumber, string Description)
    {
        var operation = new GetAccountTransactionByParameterQuery(AccountNumber, ReferenceNumber, Description);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAccountTransactionRequest AccountTransaction)
    {
        var operation = new CreateAccountTransactionCommand(AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAccountTransactionRequest AccountTransaction)
    {
        var operation = new UpdateAccountTransactionCommand(id, AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var operation = new DeleteAccountTransactionCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}