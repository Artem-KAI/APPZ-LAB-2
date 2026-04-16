using Domain.Enums;

namespace Domain.Components;

public class Battery
{
    public int CapacityMah { get; }
    public int RemainingHours { get; private set; }

    // Це система сповіщень
    public event Action<int>? BatteryChanged;

    public Battery(int capacityMah)
    {
        CapacityMah = capacityMah;
        SetMode(UsageMode.NonIntensive);
    }

    public void SetMode(UsageMode mode)
    {
        RemainingHours = CalculateHours(mode);
        BatteryChanged?.Invoke(RemainingHours);
    }

    private int CalculateHours(UsageMode mode)
    {
        if (CapacityMah >= 2000 && CapacityMah <= 3000)
        {
            if (mode == UsageMode.NonIntensive)
            {
                return 48; 
            }
            else
            {
                return 16; 
            }
        }

        if (CapacityMah >= 5000 && CapacityMah <= 7000)
        {
            if (mode == UsageMode.NonIntensive)
            {
                return 12;  
            }
            else
            {
                return 4;  
            }
        }

        return 0;
    }
}
