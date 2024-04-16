using MediatR;
using RaspberryLights.Domain.Models;

namespace RaspberryLights.Application.Commands.StartAnimation;

public class StartAnimationCommand : IRequest
{
    public StartAnimationCommand()
    {
    }

    public StartAnimationCommand(Guid deviceId, AnimationParameters animationParameters)
    {
        DeviceId = deviceId;
        AnimationParameters = animationParameters;
    }

    public Guid DeviceId { get; set; }
    public AnimationParameters AnimationParameters { get; set; }
}