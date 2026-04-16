using Domain.Devices;
using Domain.Interfaces;

namespace ConsoleApp.SecMenu;

public static class DeviceMenu
{
    // Змінюємо void на IDevice?
    public static IDevice? Select()
    {
        Console.Clear();
        Console.WriteLine("""
        1. Ноутбук (5000-7000 мАг)
        2. Смартфон (2000-3000 мАг)
        3. Планшет (2000-3000 мАг)
        0. Назад
        """);    

        string? input = Console.ReadLine();

        // Використовуємо pattern matching для красивого повернення
        return input switch
        {
            "1" => new Laptop(6000),
            "2" => new Smartphone(2500),
            "3" => new Tablet(2500),
            _ => null
        };
    }
}