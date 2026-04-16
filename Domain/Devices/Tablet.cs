using Domain.Components;

namespace Domain.Devices;

public class Tablet : DeviceBase
{
    public Tablet(int batteryMah)
        : base(
            "Tablet",
            new Battery(batteryMah),
            new Processor("Apple M1"),
            new List<Memory> { new Ram(8), new Storage(256) },
            new TouchScreen()
        )
    {
    
    }
}
