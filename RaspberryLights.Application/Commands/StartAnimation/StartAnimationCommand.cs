using MediatR;
using RaspberryLightsWebApi.Models;

namespace RaspberryLights.Application.Commands.StartAnimation;

public class StartAnimationCommand : IRequest
{
    public StartAnimationCommand()
    {
    }

    public StartAnimationCommand(Guid deviceId, AnimationParameters animationParameters)
    {
        deviceId = deviceId; // tudu ??
        AnimationParameters = animationParameters;
    }

    public Guid DeviceId { get; set; }
    public AnimationParameters AnimationParameters { get; set; }
}