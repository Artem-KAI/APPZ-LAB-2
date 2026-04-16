using Domain.Components;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Devices;

public abstract class DeviceBase : IDevice
{
    public string Name { get; }

    protected Processor Processor { get; }
    protected List<Memory> Memory { get; }
    protected TouchScreen TouchScreen { get; }
    protected Battery Battery { get; }

    // Універсальне сховище для периферії
    private readonly List<IPeripheral> _peripherals = new();

    public bool HasSoftware { get; private set; }
    public bool HasNetwork { get; private set; }
    public bool IsPluggedInToMains { get; private set; } = true;

    public int RemainingHours => Battery.RemainingHours;

    // Подія, яку тепер бачить UI
    public event Action<string, int>? BatteryLifeChanged;

    protected DeviceBase(string name, Battery battery, Processor processor, List<Memory> memory, TouchScreen touchScreen)
    {
        Name = name;
        Battery = battery;
        Processor = processor;
        Memory = memory;
        TouchScreen = touchScreen;

        // "Прокидаємо" подію від батареї назовні
        Battery.BatteryChanged += (hours) => BatteryLifeChanged?.Invoke(Name, hours);
    }

    public void InstallSoftware() => HasSoftware = true;
    public void ConnectNetwork() => HasNetwork = true;

    // Універсальне підключення будь-чого
    public void ConnectPeripheral(IPeripheral peripheral) => _peripherals.Add(peripheral);

    public void PlugInToMains() => IsPluggedInToMains = true;
    public void UnplugFromMains() => IsPluggedInToMains = false;

    // Допоміжний метод для перевірки, чи є потрібна периферія
    private bool HasPeripheral<T>() where T : IPeripheral => _peripherals.OfType<T>().Any();

    public void Perform(DeviceAction action)
    {
        // Якщо працює від розетки, батарея не розряджається
        if (IsPluggedInToMains) return;

        UsageMode mode = action switch
        {
            DeviceAction.Work or DeviceAction.PlayGame or DeviceAction.WatchVideo => UsageMode.Intensive,
            _ => UsageMode.NonIntensive
        };

        Battery.SetMode(mode);
    }

    public (bool Success, string ErrorMessage) CanPerform(DeviceAction action)
    {
        // Базові передумови для ВСІХ дій
        if (!HasSoftware)
            return (false, "Не встановлено необхідне програмне забезпечення (ПЗ).");

        if (!IsPluggedInToMains && Battery.RemainingHours <= 0)
            return (false, "Пристрій повністю розряджено. Підключіть до електромережі.");

        // Специфічні передумови залежно від дії

        // Для чату та ВІДЕО тепер потрібен інтернет
        if ((action == DeviceAction.Chat || action == DeviceAction.WatchVideo) && !HasNetwork)
            return (false, "Відсутнє підключення до Інтернету.");

        // Для музики залишаємо вимогу навушників/динаміків
        if (action == DeviceAction.ListenMusic && !HasPeripheral<AudioHeadset>())
            return (false, "Не підключено аудіопристрій (навушники).");

        if (action == DeviceAction.PrintPhoto && !HasPeripheral<PrinterDevice>())
            return (false, "Не знайдено підключеного принтера.");

        // Якщо все добре, повертаємо true і порожній рядок
        return (true, string.Empty);
    }
}