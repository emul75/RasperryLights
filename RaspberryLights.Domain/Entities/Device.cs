using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Domain.Entities;

public class Device
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public DeviceType Type { get; set; } = DeviceType.Home;    
    public string? RegistrationPlate { get; set; }
    public string? ConnectionUrl { get; set; }
    
    public Guid UserId { get; init; }
    public User User { get; init; } = null!;
}