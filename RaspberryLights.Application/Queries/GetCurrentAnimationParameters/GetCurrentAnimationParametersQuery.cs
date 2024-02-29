using MediatR;
using RaspberryLightsWebApi.Models;

namespace RaspberryLights.Application.Queries.GetCurrentAnimationParameters;

public record GetCurrentAnimationParametersQuery(Guid DeviceId) : IRequest<AnimationParameters>;