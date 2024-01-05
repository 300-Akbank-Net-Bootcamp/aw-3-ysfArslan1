using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Schema;

namespace Vb.Business.Cqrs;

public record CreateContactCommand(CreateContactRequest Model) : IRequest<IActionResult>;
public record UpdateContactCommand(int Id, UpdateContactRequest Model) : IRequest<IActionResult>;
public record DeleteContactCommand(int Id) : IRequest<IActionResult>;
public record GetAllContactQuery() : IRequest<IActionResult>;
public record GetContactByIdQuery(int Id) : IRequest<IActionResult>;
public record GetContactByParameterQuery(int CustomerNumber, string ContactType, string Information) : IRequest<IActionResult>;