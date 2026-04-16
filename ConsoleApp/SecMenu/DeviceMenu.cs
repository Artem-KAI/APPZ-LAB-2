using Domain.Builders;
using Domain.Interfaces;

namespace ConsoleApp.SecMenu;

public static class DeviceMenu
{
    public static IDevice? Select()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("""
        1. Ноутбук (Стандартна збірка)
        2. Смартфон (Стандартна збірка)
        3. Планшет (Стандартна збірка)
        4. Зібрати власний кастомний пристрій 🛠️
        0. Назад
        """);
        Console.ResetColor();

        string? input = Console.ReadLine();

        var builder = new DeviceBuilder();
        var director = new DeviceDirector(builder);

        return input switch
        {
            "1" => director.BuildStandardLaptop(),     
            "2" => director.BuildStandardSmartphone(), 
            "3" => director.BuildStandardTablet(),      
            "4" => BuildCustomDeviceInteractive(builder), 
            _ => null
        };
    }

    // Інтерактивний процес створення
    private static IDevice BuildCustomDeviceInteractive(DeviceBuilder builder)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("--- МАЙСТЕР ЗБИРАННЯ ПРИСТРОЮ ---");
        Console.ResetColor();

        Console.Write("Введіть назву пристрою (напр. MySuperPC228): ");
        string name = Console.ReadLine() ?? "Custom PC";

        Console.Write("Введіть ємність батареї (2000-7000 мАг): ");
        if (int.TryParse(Console.ReadLine(), out int battery))
            builder.SetBattery(battery);

        Console.Write("Введіть назву процесора (напр. Intel i9): ");
        string cpu = Console.ReadLine() ?? "Generic CPU";

        Console.Write("Введіть обсяг оперативної пам'яті (ГБ): ");
        if (int.TryParse(Console.ReadLine(), out int ram))
            builder.AddRam(ram);

        return builder
            .SetName(name)
            .SetProcessor(cpu)
            .Build();
    }
}