using MediatR;

namespace RaspberryLights.Application.Commands.UpdateDevice;

public class UpdateDeviceCommand : IRequest
{
    public Guid DeviceId { get; set; }
    public string? Name { get; set; }
    public string? RegistrationPlate { get; set; }
}