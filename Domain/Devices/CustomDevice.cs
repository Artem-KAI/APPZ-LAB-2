using Domain.Components;

namespace Domain.Devices;

public class CustomDevice : DeviceBase
{
    // internal конструктор, щоб цей клас можна було створити 
    // через будівельник патерн (інкапсуляція створення)
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