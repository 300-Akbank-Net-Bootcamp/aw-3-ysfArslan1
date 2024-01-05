using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Business.Cqrs;
using Vb.Schema;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator mediator;
    public AccountController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAllAccountQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpGet("{AccountNumber}")]
    public async Task<IActionResult> Get(int AccountNumber)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAccountByIdQuery(AccountNumber);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("/GetAccountByParameterQuery")]
    public async Task<IActionResult> GetAccountByParameterQuery([FromQuery]int AccountNumber, string IBAN, string Name)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAccountByParameterQuery(AccountNumber,IBAN,Name);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAccountRequest Account)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new CreateAccountCommand(Account);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{AccountNumber}")]
    public async Task<IActionResult> Put(int AccountNumber, [FromBody] UpdateAccountRequest Account)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new UpdateAccountCommand(AccountNumber, Account);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{AccountNumber}")]
    public async Task<IActionResult> Delete(int AccountNumber)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new DeleteAccountCommand(AccountNumber);
        var result = await mediator.Send(operation);
        return result;
    }
}