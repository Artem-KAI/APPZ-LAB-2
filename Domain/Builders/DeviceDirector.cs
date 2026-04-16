using Domain.Interfaces;

namespace Domain.Builders;

public class DeviceDirector
{
    private readonly DeviceBuilder _builder;

    public DeviceDirector(DeviceBuilder builder)
    {
        _builder = builder;
    }

    public IDevice BuildStandardLaptop()
    {
        return _builder
            .SetName("Ноутбук (Стандарт)")
            .SetBattery(6000)
            .SetProcessor("Intel Core i5")
            .AddRam(16)
            .AddStorage(512)
            .Build();
    }

    public IDevice BuildStandardSmartphone()
    {
        return _builder
            .SetName("Смартфон (Стандарт)")
            .SetBattery(2500)
            .SetProcessor("Snapdragon 8 Gen 2")
            .AddRam(8)
            .AddStorage(128)
            .Build();
    }

    public IDevice BuildStandardTablet()
    {
        return _builder
            .SetName("Планшет (Стандарт)")
            .SetBattery(3000)
            .SetProcessor("Apple M1")
            .AddRam(8)
            .AddStorage(256)
            .Build();
    }
}