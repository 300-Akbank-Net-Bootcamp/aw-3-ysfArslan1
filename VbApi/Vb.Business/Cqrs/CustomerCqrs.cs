using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Schema;

namespace Vb.Business.Cqrs;


public record CreateCustomerCommand(CreateCustomerRequest Model) : IRequest<IActionResult>;
public record UpdateCustomerCommand(int Id, UpdateCustomerRequest Model) : IRequest<IActionResult>;
public record DeleteCustomerCommand(int Id) : IRequest<IActionResult>;

public record GetAllCustomerQuery() : IRequest<IActionResult>;
public record GetCustomerByIdQuery(int Id) : IRequest<IActionResult>;
public record GetCustomerByParameterQuery(string IdentityNumber, string FirstName, string LastName) : IRequest<IActionResult>;