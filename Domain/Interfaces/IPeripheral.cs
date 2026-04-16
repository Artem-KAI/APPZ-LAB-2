namespace Domain.Interfaces;

public interface IPeripheral
{
    string Name { get; }
}

public class AudioHeadset : IPeripheral 
{
    public string Name => "Навушники"; 
}
public class PrinterDevice : IPeripheral 
{
    public string Name => "Принтер"; 
}