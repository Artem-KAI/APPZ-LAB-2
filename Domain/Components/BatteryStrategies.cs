using Domain.Enums;

namespace Domain.Components;

// Абстракція алгоритму розрахунку
public interface IBatteryDrainStrategy
{
    int CalculateHours(UsageMode mode);
}

// Стратегія для батарей 2000-3000 мАг
public class StandardCapacityStrategy : IBatteryDrainStrategy
{
    public int CalculateHours(UsageMode mode)
    {
        return mode == UsageMode.NonIntensive ? 48 : 16;
    }
}

// Стратегія для батарей 5000-7000 мАг
public class HighCapacityStrategy : IBatteryDrainStrategy
{
    public int CalculateHours(UsageMode mode)
    {
        return mode == UsageMode.NonIntensive ? 12 : 4;
    }
}