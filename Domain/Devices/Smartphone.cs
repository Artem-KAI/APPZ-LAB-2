using Domain.Components;

namespace Domain.Devices;

public class Smartphone : DeviceBase
{
    public Smartphone(int batteryMah)
        : base(
            "Smartphone",
            new Battery(batteryMah, new StandardCapacityStrategy()),
            new Processor("Snapdragon"),
            new List<Memory> { new Ram(8), new Storage(128) },
            new TouchScreen()
        )
    {
    
    }
}
