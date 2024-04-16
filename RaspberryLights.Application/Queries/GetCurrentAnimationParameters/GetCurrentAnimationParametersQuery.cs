using MediatR;
using RaspberryLights.Domain.Models;

namespace RaspberryLights.Application.Queries.GetCurrentAnimationParameters;

public record GetCurrentAnimationParametersQuery(Guid DeviceId) : IRequest<AnimationParameters>;