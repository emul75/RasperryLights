using MediatR;

namespace RaspberryLights.Application.Commands.DeleteDevice;

public class DeleteDeviceCommand : IRequest
{
    public DeleteDeviceCommand(Guid deviceId)
    {
        DeviceId = deviceId;
    }

    public Guid DeviceId { get; set; }
}