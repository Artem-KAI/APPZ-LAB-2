using ConsoleApp;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        var menu = new AppMenu();
        menu.Run();
    }
}