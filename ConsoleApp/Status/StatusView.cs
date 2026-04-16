// Файл: ConsoleApp.Status/StatusView.cs
using Domain.Interfaces;

namespace ConsoleApp.Status;

public static class StatusView
{
    public static void Show(IDevice? device)
    {
        if (device == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║      ТЕХНІКА ЩЕ НЕ ВИБРАНА         ║");
            Console.WriteLine("╚════════════════════════════════════╝\n");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine($"║ ПРИСТРІЙ: {device.Name.PadRight(24)} ║");
        Console.WriteLine("╠════════════════════════════════════╣");

        Console.WriteLine($"║ ПЗ:       {(device.HasSoftware ? "[ Встановлено ]" : "[ Відсутнє    ]").PadRight(24)} ║");
        Console.WriteLine($"║ Інтернет: {(device.HasNetwork ? "[ Підключено  ]" : "[ Немає       ]").PadRight(24)} ║");
        Console.WriteLine($"║ Живлення: {(device.IsPluggedInToMains ? "[ Від мережі  ]" : "[ Акумулятор  ]").PadRight(24)} ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();

        if (!device.IsPluggedInToMains)
        {
            Console.ForegroundColor = device.RemainingHours > 10 ? ConsoleColor.Yellow : ConsoleColor.Red;
            Console.WriteLine($"Залишок заряду (поточний режим): {device.RemainingHours} год.\n");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("     Працює від мережі (безліміт)\n");
            Console.ResetColor();
        }
    }
}