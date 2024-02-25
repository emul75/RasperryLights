namespace RaspberryLights.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public ICollection<Device> Devices { get; set; }
}