using Domain.Enums;
using Domain.Events;

namespace Domain.Interfaces;

public interface IDevice
{
    string Name { get; }
    bool HasSoftware { get; }
    bool HasNetwork { get; }
    bool IsPluggedInToMains { get; }
    int RemainingHours { get; }

    event EventHandler<DeviceEventArgs>? BatteryLifeChanged; // observer pattern

    void InstallSoftware();
    void ConnectNetwork();
    void ConnectPeripheral(IPeripheral peripheral); 
    void PlugInToMains();    
    void UnplugFromMains();  

    (bool Success, string ErrorMessage) CanPerform(DeviceAction action);
    void Perform(DeviceAction action);
}