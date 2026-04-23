using Domain.Enums;

namespace Domain.Components;

public class Battery
{
    public int CapacityMah { get; }
    public int RemainingHours { get; private set; }

    private readonly IBatteryDrainStrategy _drainStrategy;// strategy

    public event Action<int>? BatteryChanged;// observer

    public Battery(int capacityMah, IBatteryDrainStrategy drainStrategy)
    {
        CapacityMah = capacityMah;
        _drainStrategy = drainStrategy;
        SetMode(UsageMode.NonIntensive);
    }

    public void SetMode(UsageMode mode)
    {
        RemainingHours = _drainStrategy.CalculateHours(mode);
        BatteryChanged?.Invoke(RemainingHours);
    }
}