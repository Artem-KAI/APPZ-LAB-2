using Domain.Events;
using Domain.Interfaces;

namespace ConsoleApp.Observers;

// Клас-спостерігач (Observer)
public class ConsoleDeviceObserver
{
    // Метод-підписка (Subscription handler)
    public void OnDeviceStateChanged(object? sender, DeviceEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n[СПОСТЕРІГАЧ СПОВІЩАЄ]: Пристрій '{e.DeviceName}' змінив режим використання.");
        Console.WriteLine($"[СПОСТЕРІГАЧ СПОВІЩАЄ]: Залишок роботи від батареї: {e.RemainingHours} год.\n");
        Console.ResetColor();
    }

    // Зручний метод для оформлення підписки
    public void Subscribe(IDevice device)
    {
        device.BatteryLifeChanged += OnDeviceStateChanged;
    }

    // Зручний метод для відписки
    public void Unsubscribe(IDevice device)
    {
        device.BatteryLifeChanged -= OnDeviceStateChanged;
    }
}