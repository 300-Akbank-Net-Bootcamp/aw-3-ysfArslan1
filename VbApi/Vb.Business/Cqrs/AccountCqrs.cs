using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Schema;

namespace Vb.Business.Cqrs;

public record CreateAccountCommand(CreateAccountRequest Model) : IRequest<IActionResult>;
public record UpdateAccountCommand(int Id, UpdateAccountRequest Model) : IRequest<IActionResult>;
public record DeleteAccountCommand(int Id) : IRequest<IActionResult>;


public record GetAllAccountQuery() : IRequest<IActionResult>;
public record GetAccountByIdQuery(int Id) : IRequest<IActionResult>;
public record GetAccountByParameterQuery(int AccountNumber, string IBAN, string Name) : IRequest<IActionResult>;
