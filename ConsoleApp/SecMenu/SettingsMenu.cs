using Domain.Components; 
using Domain.Interfaces;

namespace ConsoleApp.SecMenu;

public static class SettingsMenu
{
    public static void Show(IDevice? device)
    {
        if (device == null) return;

        Console.Clear();
        Console.WriteLine("""
        1. Встановити ПЗ
        2. Підключитись до мережі
        3. Підключити навушники (Аудіо)
        4. Підключити принтер
        0. Назад
        """);

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