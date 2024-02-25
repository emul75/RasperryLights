using RaspberryLights.Domain.Entities;
using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Mvc.Models;

public class DeviceDto
{
    public string? Name { get; set; }
    public string? RegistrationNumber { get; set; }
    public ConnectionStatus ConnectionStatus { get; set; }
    public Animation CurrentAnimation { get; set; }
    public Guid Id { get; set; }

    public static DeviceDto Map(Device device)
    {
        return new DeviceDto
        {
            ConnectionStatus = ConnectionStatus.Disconnected,
            Id = device.Id,
            Name = device.Name,
            RegistrationNumber = device.RegistrationPlate
        };
    }
}