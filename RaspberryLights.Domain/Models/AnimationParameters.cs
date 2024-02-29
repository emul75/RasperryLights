using RaspberryLights.Domain.Enums;

namespace RaspberryLightsWebApi.Models;

public class AnimationParameters
{
    public Animation Animation { get; set; }
    public SimpleColor CustomColor { get; set; }
    public SpeedType SpeedType { get; set; }
    public byte UserDefinedSpeed { get; set; }
    public byte Brightness { get; set; }

    public class SimpleColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }
}