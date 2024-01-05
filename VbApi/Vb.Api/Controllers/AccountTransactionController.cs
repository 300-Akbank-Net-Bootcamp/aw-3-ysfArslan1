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

    // AccountTransaction Tablosundaki nesnelerin tamam�n� almak i�in kullan�l�r 
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAllAccountTransactionQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction Tablosundaki id degeri g�nderilen nesneyi almak i�in kullan�l�r 
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAccountTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    // AccountTransaction Tablosundaki istenilen degerleri g�nderilen nesneyi almak i�in kullan�l�r
    [HttpGet("/GetAccountTransactionByParameterQuery")]
    public async Task<IActionResult> GetAccountTransactionByParameterQuery([FromQuery] int AccountNumber, string ReferenceNumber, string Description)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAccountTransactionByParameterQuery(AccountNumber, ReferenceNumber, Description);
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction nesnesini database eklemek i�in kullan�l�r
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAccountTransactionRequest AccountTransaction)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new CreateAccountTransactionCommand(AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction Tablosundaki id degeri g�nderilen nesneyi d�zenlemek i�in kullan�l�r 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateAccountTransactionRequest AccountTransaction)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new UpdateAccountTransactionCommand(id, AccountTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    // AccountTransaction Tablosundaki id degeri g�nderilen nesneyi silmek i�in kullan�l�r 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new DeleteAccountTransactionCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}