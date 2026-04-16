using Domain.Interfaces;

namespace ConsoleApp.SecMenu;

public static class PowerMenu
{
    // Приймаємо device
    public static void Show(IDevice? device)
    {
        if (device == null) return;

        Console.Clear();
        Console.WriteLine("""
        1. Підключити до розетки (Увімкнути живлення)
        2. Відключити від розетки (Робота від батареї)
        0. Назад
        """);

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                device.PlugInToMains(); // Оновлений метод
                break;
            case "2":
                device.UnplugFromMains(); // Оновлений метод
                break;
        }
    }
}