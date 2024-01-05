using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Schema;

namespace Vb.Business.Cqrs;

public record CreateAccountTransactionCommand(CreateAccountTransactionRequest Model) : IRequest<IActionResult>;
public record UpdateAccountTransactionCommand(int Id, UpdateAccountTransactionRequest Model) : IRequest<IActionResult>;
public record DeleteAccountTransactionCommand(int Id) : IRequest<IActionResult>;
public record GetAllAccountTransactionQuery() : IRequest<IActionResult>;
public record GetAccountTransactionByIdQuery(int Id) : IRequest<IActionResult>;
public record GetAccountTransactionByParameterQuery(int AccountNumber, string ReferenceNumber, string Description) : IRequest<IActionResult>;