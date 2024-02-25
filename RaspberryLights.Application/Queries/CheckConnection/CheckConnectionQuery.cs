using MediatR;
using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Application.Queries.CheckConnection;

public record CheckConnectionQuery(string? DeviceUrl) : IRequest<ConnectionStatus>;