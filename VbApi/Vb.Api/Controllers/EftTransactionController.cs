using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EftTransactionController : ControllerBase
{
    private readonly IMediator mediator;
    public EftTransactionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var operation = new GetAllEftTransactionQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var operation = new GetEftTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("/GetEftTransactionByParameterQuery")]
    public async Task<IActionResult> GetEftTransactionByParameterQuery([FromQuery] int AccountNumber, string ReferenceNumber, string SenderIban)
    {
        var operation = new GetEftTransactionByParameterQuery(AccountNumber, ReferenceNumber, SenderIban);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEftTransactionRequest EftTransaction)
    {
        var operation = new CreateEftTransactionCommand(EftTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateEftTransactionRequest EftTransaction)
    {
        var operation = new UpdateEftTransactionCommand(id, EftTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var operation = new DeleteEftTransactionCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}