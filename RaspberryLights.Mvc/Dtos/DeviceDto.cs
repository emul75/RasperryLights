using RaspberryLights.Domain.Entities;
using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Mvc.Dtos;

public class DeviceDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; } // todo - name shouldn't be null
    public DeviceType Type { get; set; }
    public string? RegistrationNumber { get; set; }
    public ConnectionStatus ConnectionStatus { get; set; }

    public static DeviceDto Map(Device device)
    {
        return new DeviceDto
        {
            Id = device.Id,
            Name = device.Name,
            RegistrationNumber = device.RegistrationPlate,
            Type = device.Type,
            ConnectionStatus = ConnectionStatus.Disconnected
        };
    }
}