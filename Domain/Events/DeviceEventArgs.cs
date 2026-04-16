namespace Domain.Events;

public class DeviceEventArgs : EventArgs
{
    public string DeviceName { get; }
    public int RemainingHours { get; }

    public DeviceEventArgs(string deviceName, int remainingHours)
    {
        DeviceName = deviceName;
        RemainingHours = remainingHours;
    }
}