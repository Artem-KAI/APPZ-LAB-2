using Domain.Enums;

namespace Domain.Components;

public class Battery
{
    public int CapacityMah { get; }
    public int RemainingHours { get; private set; }

    // Ін'єкція залежності для патерну Strategy
    private readonly IBatteryDrainStrategy _drainStrategy;

    public event Action<int>? BatteryChanged;

    public Battery(int capacityMah, IBatteryDrainStrategy drainStrategy)
    {
        CapacityMah = capacityMah;
        _drainStrategy = drainStrategy;
        SetMode(UsageMode.NonIntensive);
    }

    public void SetMode(UsageMode mode)
    {
        // Делегуємо розрахунок обраній стратегії
        RemainingHours = _drainStrategy.CalculateHours(mode);
        BatteryChanged?.Invoke(RemainingHours);
    }
}