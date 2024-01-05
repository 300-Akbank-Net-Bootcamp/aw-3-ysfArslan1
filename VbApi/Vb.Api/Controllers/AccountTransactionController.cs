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

    // AccountTransaction Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAllAccountTransactionQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAccountTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    // AccountTransaction Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    [HttpGet("/GetAccountTransactionByParameterQuery")]
    public async Task<IActionResult> GetAccountTransactionByParameterQuery([FromQuery] int AccountNumber, string ReferenceNumber, string Description)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAccountTransactionByParameterQuery(AccountNumber, ReferenceNumber, Description);
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction nesnesini database eklemek için kullanýlýr
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAccountTransactionRequest AccountTransaction)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new CreateAccountTransactionCommand(AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction Tablosundaki id degeri gönderilen nesneyi düzenlemek için kullanýlýr 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAccountTransactionRequest AccountTransaction)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new UpdateAccountTransactionCommand(id, AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction Tablosundaki id degeri gönderilen nesneyi silmek için kullanýlýr 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new DeleteAccountTransactionCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}