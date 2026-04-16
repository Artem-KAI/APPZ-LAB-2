using Domain.Interfaces;

namespace ConsoleApp.SecMenu;

public static class PowerMenu
{
    public static void Show(IDevice? device)
    {
        if (device == null) return;

        Console.Clear();
        Console.WriteLine("1. Підключити до розетки (Увімкнути живлення)");
        Console.WriteLine("2. Відключити від розетки (Робота від батареї)");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("0. Назад");
        Console.ResetColor();
        Console.Write("\nОберіть дію: ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                device.PlugInToMains();  
                break;
            case "2":
                device.UnplugFromMains(); 
                break;
        }
    }
}