using Domain.Components;
using Domain.Devices;
using Domain.Interfaces;

namespace Domain.Builders;

public class DeviceBuilder
{
    private string _name = "Custom Device";
    private int _batteryCapacity = 3000;
    private string _processorModel = "Generic CPU";
    private readonly List<Memory> _memory = new();
    private TouchScreen _touchScreen = new TouchScreen(); 

    public DeviceBuilder SetName(string name)
    {
        _name = name;
        return this; 
    }

    public DeviceBuilder SetBattery(int capacityMah)
    {
        _batteryCapacity = capacityMah;
        return this;
    }

    public DeviceBuilder SetProcessor(string model)
    {
        _processorModel = model;
        return this;
    }

    public DeviceBuilder AddRam(int sizeGb)
    {
        _memory.Add(new Ram(sizeGb));
        return this;
    }

    public DeviceBuilder AddStorage(int sizeGb)
    {
        _memory.Add(new Storage(sizeGb));
        return this;
    }

    public IDevice Build()
    {
        IBatteryDrainStrategy strategy = _batteryCapacity >= 5000
            ? new HighCapacityStrategy()
            : new StandardCapacityStrategy();

        var battery = new Battery(_batteryCapacity, strategy);
        var processor = new Processor(_processorModel);

        if (!_memory.Any())
        {
            _memory.Add(new Ram(4));
            _memory.Add(new Storage(64));
        }

        return new CustomDevice(_name, battery, processor, _memory, _touchScreen);
    }
}