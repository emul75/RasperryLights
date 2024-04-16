using RaspberryLights.Domain.Enums;

namespace RaspberryLights.Domain.Models;

public class AnimationParameters
{
    public Animation Animation { get; set; } = Animation.Off;
    public SimpleColor CustomColor { get; set; } = new SimpleColor();
    public SpeedType SpeedType { get; set; } = SpeedType.UserDefined;
    public byte UserDefinedSpeed { get; set; } = 234;
    public byte Brightness { get; set; } = byte.MaxValue;

    public class SimpleColor
    {
        public byte R { get; set; } = 0;
        public byte G { get; set; } = 0;
        public byte B { get; set; } = 0;

        public string ToHexString()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }
    }
}