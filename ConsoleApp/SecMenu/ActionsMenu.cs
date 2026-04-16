using Application;
using Domain.Enums;

namespace ConsoleApp.SecMenu;

public static class ActionsMenu
{
    public static void Show(DeviceService? service)
    {
        if (service == null) return;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║            МЕНЮ ДІЙ                ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine(" 1. Працювати");
        Console.WriteLine(" 2. Чатитися");
        Console.WriteLine(" 3. Слухати музику");
        Console.WriteLine(" 4. Дивитись відео");
        Console.WriteLine(" 5. Грати");
        Console.WriteLine(" 6. Друкувати фото");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(" 0. Назад");
        Console.ResetColor();
        Console.Write("\nОберіть дію: ");

        string? input = Console.ReadLine();
        DeviceAction? action = input switch
        {
            "1" => DeviceAction.Work,
            "2" => DeviceAction.Chat,
            "3" => DeviceAction.ListenMusic,
            "4" => DeviceAction.WatchVideo,
            "5" => DeviceAction.PlayGame,
            "6" => DeviceAction.PrintPhoto,
            _ => null
        };

        if (action == null) return;

        var result = service.TryPerform(action.Value);

        Console.WriteLine("\n--------------------------------------");
        if (result.Success)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{result.ErrorMessage}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Неможливо виконати: {result.ErrorMessage}");
        }
        Console.ResetColor();

    }
}