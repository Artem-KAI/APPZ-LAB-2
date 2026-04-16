using Domain.Components; 
using Domain.Interfaces;

namespace ConsoleApp.SecMenu;

public static class SettingsMenu
{
    public static void Show(IDevice? device)
    {
        if (device == null) return;

        Console.Clear();
        Console.WriteLine("1. Встановити ПЗ");
        Console.WriteLine("2. Підключитись до мережі");
        Console.WriteLine("3. Підключити навушники (Аудіо)");
        Console.WriteLine("4. Підключити принтер");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("0. Назад");
        Console.ResetColor();
        Console.Write("\nОберіть дію: ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                device.InstallSoftware();
                break;
            case "2":
                device.ConnectNetwork();
                break;
            case "3":
                device.ConnectPeripheral(new AudioHeadset());  
                break;
            case "4":
                device.ConnectPeripheral(new PrinterDevice()); 
                break;
        }
    }
}