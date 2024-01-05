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

    [HttpGet]// EftTransaction Tablosundaki nesnelerin tamamýný almak için kullanýlýr 
    public async Task<IActionResult> Get()
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetAllEftTransactionQuery(); 
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")] // EftTransaction Tablosundaki id degeri gönderilen nesneyi almak için kullanýlýr 
    public async Task<IActionResult> Get(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetEftTransactionByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    // EftTransaction Tablosundaki istenilen degerleri gönderilen nesneyi almak için kullanýlýr
    [HttpGet("/GetEftTransactionByParameterQuery")]
    public async Task<IActionResult> GetEftTransactionByParameterQuery([FromQuery] int AccountNumber, string ReferenceNumber, string SenderIban)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new GetEftTransactionByParameterQuery(AccountNumber, ReferenceNumber, SenderIban);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]// EftTransaction nesnesini database eklemek için kullanýlýr
    public async Task<IActionResult> Post([FromBody] CreateEftTransactionRequest EftTransaction)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new CreateEftTransactionCommand(EftTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]// EftTransaction Tablosundaki id degeri gönderilen nesneyi düzenlemek için kullanýlýr 
    public async Task<IActionResult> Put(int id, [FromBody] UpdateEftTransactionRequest EftTransaction)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new UpdateEftTransactionCommand(id, EftTransaction);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]// EftTransaction Tablosundaki id degeri gönderilen nesneyi silmek için kullanýlýr 
    public async Task<IActionResult> Delete(int id)
    {
        // operasyon oluþturulur, oluþturulan operasyon mediater ile gönderilir.
        var operation = new DeleteEftTransactionCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}