using Domain.Components;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces;

namespace Domain.Devices;

public abstract class DeviceBase : IDevice
{
    // залежності, компоненти пристрою
    public string Name { get; }    
    protected Processor Processor { get; }
    protected List<Memory> Memory { get; }
    protected TouchScreen TouchScreen { get; }
    protected Battery Battery { get; }

    private readonly List<IPeripheral> _peripherals = new();


    // стан пристрою
    public bool HasSoftware { get; private set; }
    public bool HasNetwork { get; private set; }
    public bool IsPluggedInToMains { get; private set; } = true;
    public int RemainingHours => Battery.RemainingHours;

    

    public event EventHandler<DeviceEventArgs>? BatteryLifeChanged; // observer pattern
    


    protected DeviceBase(string name, Battery battery, Processor processor, List<Memory> memory, TouchScreen touchScreen)
    {
        Name = name;
        Battery = battery;
        Processor = processor;
        Memory = memory;
        TouchScreen = touchScreen;

        Battery.BatteryChanged += (hours) => BatteryLifeChanged?.Invoke(this, new DeviceEventArgs(Name, hours)); // observer pattern
    }


    // керування станом пристрою
    public void InstallSoftware() => HasSoftware = true;
    public void ConnectNetwork() => HasNetwork = true;
    public void ConnectPeripheral(IPeripheral peripheral) => _peripherals.Add(peripheral);

    public void PlugInToMains() => IsPluggedInToMains = true;
    public void UnplugFromMains() => IsPluggedInToMains = false;

    private bool HasPeripheral<T>() where T : IPeripheral => _peripherals.OfType<T>().Any();


    // бізнес логіка виконання дій
    public void Perform(DeviceAction action)
    {
        if (IsPluggedInToMains) 
            return;

        UsageMode mode = action switch
        {
            DeviceAction.Work 
            or DeviceAction.PlayGame or DeviceAction.WatchVideo => UsageMode.Intensive,
            _ => UsageMode.NonIntensive
        };

        Battery.SetMode(mode);
    }

    public (bool Success, string ErrorMessage) CanPerform(DeviceAction action)
    {
        if (!HasSoftware)
            return (false, "Не встановлено необхідне програмне забезпечення (ПЗ).");

        if (!IsPluggedInToMains && Battery.RemainingHours <= 0)
            return (false, "Пристрій повністю розряджено. Підключіть до електромережі.");

        if ((action == DeviceAction.Chat || action == DeviceAction.WatchVideo) && !HasNetwork)
            return (false, "Відсутнє підключення до Інтернету.");

        if (action == DeviceAction.ListenMusic && !HasPeripheral<AudioHeadset>())
            return (false, "Не підключено аудіопристрій (навушники).");

        if (action == DeviceAction.PrintPhoto && !HasPeripheral<PrinterDevice>())
            return (false, "Не знайдено підключеного принтера.");

        return (true, string.Empty);
    }
}