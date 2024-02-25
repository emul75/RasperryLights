using MediatR;

namespace RaspberryLights.Application.Commands.UpdateDeviceIp;

public class UpdateDeviceIpCommand : IRequest
{
    public Guid DeviceId { get; set; }
    public string? NewIp { get; set; }
}