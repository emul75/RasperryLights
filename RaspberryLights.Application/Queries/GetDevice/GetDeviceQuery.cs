using MediatR;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Application.Queries.GetDevice;

public record GetDeviceQuery(Guid? Id = null, string? RegistrationPlate = null) : IRequest<Device>;