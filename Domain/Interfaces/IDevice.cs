using Domain.Enums;

namespace Domain.Interfaces;

public interface IDevice
{
    string Name { get; }
    bool HasSoftware { get; }
    bool HasNetwork { get; }
    bool IsPluggedInToMains { get; } // Замість PowerOn
    int RemainingHours { get; }

    // Ось вона - подія для твого UI!
    event Action<string, int>? BatteryLifeChanged;

    void InstallSoftware();
    void ConnectNetwork();
    void ConnectPeripheral(IPeripheral peripheral); // Універсальний метод
    void PlugInToMains();    // Замість EnablePower
    void UnplugFromMains();  // Замість DisablePower

    (bool Success, string ErrorMessage) CanPerform(DeviceAction action);

    //bool CanPerform(DeviceAction action);
    void Perform(DeviceAction action);
}