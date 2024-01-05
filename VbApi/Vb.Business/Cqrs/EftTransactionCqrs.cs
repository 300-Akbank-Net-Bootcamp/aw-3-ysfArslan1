using MediatR;
using Vb.Base.Response;
using Microsoft.AspNetCore.Mvc;

using Vb.Schema;

namespace Vb.Business.Cqrs;

public record CreateEftTransactionCommand(CreateEftTransactionRequest Model) : IRequest<IActionResult>;
public record UpdateEftTransactionCommand(int Id, UpdateEftTransactionRequest Model) : IRequest<IActionResult>;
public record DeleteEftTransactionCommand(int Id) : IRequest<IActionResult>;
public record GetAllEftTransactionQuery() : IRequest<IActionResult>;
public record GetEftTransactionByIdQuery(int Id) : IRequest<IActionResult>;
public record GetEftTransactionByParameterQuery(int AccountNumber, string ReferenceNumber, string SenderIban) : IRequest<IActionResult>;