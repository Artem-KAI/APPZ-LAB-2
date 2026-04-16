using Application;
using ConsoleApp.Observers;
using ConsoleApp.SecMenu;
using ConsoleApp.Status;
using Domain.Interfaces;

namespace ConsoleApp;

public class AppMenu 
{
    private IDevice? _device;
    private DeviceService? _service;

    // екземпляр спостерігача
    private readonly ConsoleDeviceObserver _observer = new(); // observer pattern

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            StatusView.Show(_device);

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
                    SettingsMenu.Show(_device); 
                    break;
                case "3":
                    ActionsMenu.Show(_service);
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
        if (_device != null) _observer.Unsubscribe(_device);

        _device = DeviceMenu.Select();

        if (_device != null)
        {
            _service = new DeviceService(_device);
            
            _observer.Subscribe(_device);

            Console.WriteLine($"\n[INFO] {_device.Name} підключено до системи спостереження.");
            Console.ReadKey();
        }
    }
}
