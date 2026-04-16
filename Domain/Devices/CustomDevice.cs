using Domain.Components;

namespace Domain.Devices;

public class CustomDevice : DeviceBase
{
    internal CustomDevice(
        string name,
        Battery battery,
        Processor processor,
        List<Memory> memory,
        TouchScreen touchScreen)
        : base(name, battery, processor, memory, touchScreen)
    {

    }
}