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

    [HttpGet]// EftTransaction Tablosundaki nesnelerin tamam�n� almak i�in kullan�l�r 
    public async Task<IActionResult> Get()
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetAllEftTransactionQuery(); 
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")] // EftTransaction Tablosundaki id degeri g�nderilen nesneyi almak i�in kullan�l�r 
    public async Task<IActionResult> Get(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetEftTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    // EftTransaction Tablosundaki istenilen degerleri g�nderilen nesneyi almak i�in kullan�l�r
    [HttpGet("/GetEftTransactionByParameterQuery")]
    public async Task<IActionResult> GetEftTransactionByParameterQuery([FromQuery] int AccountNumber, string ReferenceNumber, string SenderIban)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new GetEftTransactionByParameterQuery(AccountNumber, ReferenceNumber, SenderIban);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]// EftTransaction nesnesini database eklemek i�in kullan�l�r
    public async Task<IActionResult> Post([FromBody] CreateEftTransactionRequest EftTransaction)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new CreateEftTransactionCommand(EftTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]// EftTransaction Tablosundaki id degeri g�nderilen nesneyi d�zenlemek i�in kullan�l�r 
    public async Task<IActionResult> Put(int id, [FromBody] UpdateEftTransactionRequest EftTransaction)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new UpdateEftTransactionCommand(id, EftTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]// EftTransaction Tablosundaki id degeri g�nderilen nesneyi silmek i�in kullan�l�r 
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon olu�turulur, olu�turulan operasyon mediater ile g�nderilir.
        var operation = new DeleteEftTransactionCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}