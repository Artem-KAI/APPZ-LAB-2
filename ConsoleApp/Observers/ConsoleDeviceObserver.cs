using Domain.Events;
using Domain.Interfaces;

namespace ConsoleApp.Observers;
 
public class ConsoleDeviceObserver
{ 
    public void OnDeviceStateChanged(object? sender, DeviceEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n[СПОСТЕРІГАЧ]: Пристрій [{e.DeviceName}] змінив режим використання.");
        Console.WriteLine($"[СПОСТЕРІГАЧ]: Залишок роботи від батареї: {e.RemainingHours} год.\n");
        Console.ResetColor();
    }

    public void Subscribe(IDevice device)
    {
        device.BatteryLifeChanged += OnDeviceStateChanged;
    }


    public void Unsubscribe(IDevice device)
    {
        device.BatteryLifeChanged -= OnDeviceStateChanged;
    }
}