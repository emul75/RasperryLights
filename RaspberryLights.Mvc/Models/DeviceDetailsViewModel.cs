using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Mvc.Models;

public class DeviceDetailsViewModel
{
    public DeviceDetailsViewModel(DeviceDto device)
    {
        Device = device;
    }

    public DeviceDto Device { get; set; }

    public List<Animation> AvailableAnimations { get; set; } =
        Enum.GetValues(typeof(Animation))
            .Cast<Animation>()
            .ToList();
}