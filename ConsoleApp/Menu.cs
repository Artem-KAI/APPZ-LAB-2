using Application;
using ConsoleApp.SecMenu;
using ConsoleApp.Status;
using Domain.Interfaces;

namespace ConsoleApp;

public class AppMenu // Більше не static!
{
    private IDevice? _device;
    private DeviceService? _service;

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            StatusView.Show(_device); // Передаємо залежність явно

            Console.WriteLine("""
            1. Вибрати техніку
            2. Налаштування
            3. Дія
            4. Вкл/Викл енергію
            0. Вихід
            """);
           
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SelectDevice();
                    break;
                case "2":
                    SettingsMenu.Show(_device); // Передаємо пристрій як параметр
                    break;
                case "3":
                    ActionsMenu.Show(_service); // Передаємо сервіс як параметр
                    break;
                case "4":
                    PowerMenu.Show(_device);
                    break;
                case "0":
                    return;
            }
        }
    }

    private void SelectDevice()
    {
        _device = DeviceMenu.Select(); // DeviceMenu повертає IDevice, а не пише в static

        if (_device != null)
        {
            _service = new DeviceService(_device);

            // ТУТ МИ ВИКОНУЄМО ВИМОГУ ТЗ ПРО ПОДІЇ!
            _device.BatteryLifeChanged += OnBatteryChanged;
        }
    }

    // Метод-обробник події
    private void OnBatteryChanged(string deviceName, int remainingHours)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n[СПОВІЩЕННЯ] {deviceName} змінив споживання енергії. Заряду вистачить на {remainingHours} год.");
        Console.ResetColor();
    }
}

//using Application;
//using ConsoleApp.SecMenu;
//using ConsoleApp.Status;
//using Domain.Interfaces;

//namespace ConsoleApp;

//public static class Menu
//{
//    public static IDevice? Device { get; set; }
//    public static DeviceService? Service { get; set; }

//    public static void Run()
//    {
//        while (true)
//        {
//            Console.Clear();
//            StatusView.Show(Device);

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("""
//            1. Вибрати техніку
//            2. Налаштування
//            3. Дія
//            4. Вкл/Викл енергію
//            0. Вихід
//            """);
//            Console.ResetColor();

//            string? input = Console.ReadLine();

//            switch (input)
//            {
//                case "1": DeviceMenu.Select(); 
//                    break;
//                case "2": SettingsMenu.Show(); 
//                    break;
//                case "3": ActionsMenu.Show(); 
//                    break;
//                case "4": PowerMenu.Show(); 
//                    break;
//                case "0": 
//                    return;

//                default:
//                    break;
//            }
//        }
//    }
//}