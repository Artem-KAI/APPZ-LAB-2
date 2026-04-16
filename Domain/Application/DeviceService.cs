using Domain.Enums;
using Domain.Interfaces;

namespace Application;

public class DeviceService
{
    private readonly IDevice _device;

    public DeviceService(IDevice device)
    {
        _device = device;
    }

    public (bool Success, string ErrorMessage) TryPerform(DeviceAction action)
    {
        var checkResult = _device.CanPerform(action);

        if (!checkResult.Success)
        {
            return checkResult; 
        }

        _device.Perform(action);

        return (true, "Дію успішно виконано!");
    }
}