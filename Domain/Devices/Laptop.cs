using Domain.Components;

namespace Domain.Devices;

public class Laptop : DeviceBase
{
    public Laptop(int batteryMah)
        : base(
            "Laptop",
            new Battery(batteryMah, new StandardCapacityStrategy()),
            new Processor("Intel Core i5"),
            new List<Memory> { new Ram(16), new Storage(512) },
            new TouchScreen()
        )
    {
    }
}
