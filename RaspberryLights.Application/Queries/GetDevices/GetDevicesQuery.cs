using MediatR;
using RaspberryLights.Domain.Entities;

namespace RaspberryLights.Application.Queries.GetDevices;

public record GetDevicesQuery(Guid? UserId = null) : IRequest<IEnumerable<Device>>;