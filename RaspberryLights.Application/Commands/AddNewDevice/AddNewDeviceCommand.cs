using MediatR;
using RaspberryLights.Domain.Entities;
using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Application.Commands.AddNewDevice;

public class AddNewDeviceCommand : IRequest<Device>
{
    public Guid DeviceId { get; set; }
    public string? Name { get; set; }
    public DeviceType Type { get; set; }    
    public string? RegistrationPlate { get; set; }
}