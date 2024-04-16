using RaspberryLights.Domain.Enums;
using RaspberryLights.Domain.Models;
using RaspberryLights.Mvc.Dtos;

namespace RaspberryLights.Mvc.Models;

public class DeviceDetailsViewModel(DeviceDto device, AnimationParameters animationParameters)
{
    public DeviceDto Device { get; set; } = device;
    public AnimationParameters AnimationParameters { get; set; } = animationParameters;

    public List<Animation> AvailableAnimations { get; set; } =
        Enum.GetValues(typeof(Animation))
            .Cast<Animation>()
            .ToList();

    public List<SpeedType> AvailableSpeedTypes { get; set; } =
        Enum.GetValues(typeof(SpeedType))
            .Cast<SpeedType>()
            .Where(st=>st == SpeedType.UserDefined || device.Type == DeviceType.Car)
            .ToList();

    public List<DeviceType> AvailableDeviceTypes { get; set; } =
        Enum.GetValues(typeof(DeviceType))
            .Cast<DeviceType>()
            .ToList();
}