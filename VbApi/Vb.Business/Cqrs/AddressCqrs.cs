using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vb.Base.Response;
using Vb.Schema;

namespace Vb.Business.Cqrs;

public record CreateAddressCommand(CreateAddressRequest Model) : IRequest<IActionResult>;
public record UpdateAddressCommand(int Id, UpdateAddressRequest Model) : IRequest<IActionResult>;
public record DeleteAddressCommand(int Id) : IRequest<IActionResult>;
public record GetAllAddressQuery() : IRequest<IActionResult>;
public record GetAddressByIdQuery(int Id) : IRequest<IActionResult>;
public record GetAddressByParameterQuery(int CustomerNumber, string Address1, string City) : IRequest<IActionResult>;