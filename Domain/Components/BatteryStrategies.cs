using Domain.Enums;

namespace Domain.Components;
 
public interface IBatteryDrainStrategy
{
    int CalculateHours(UsageMode mode);
}

// 2000-3000 мАг
public class StandardCapacityStrategy : IBatteryDrainStrategy
{
    public int CalculateHours(UsageMode mode)
    {
        if (mode == UsageMode.NonIntensive)
            return 48; 
        else
            return 16;   
    }
}

// 5000-7000 мАг
public class HighCapacityStrategy : IBatteryDrainStrategy
{
    public int CalculateHours(UsageMode mode)
    {
        if (mode == UsageMode.NonIntensive)
            return 12;
        else        
            return 4; 
    }
}