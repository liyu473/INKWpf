using CommunityToolkit.Mvvm.Input;
using LyuEModbus.Abstractions;
using LyuEModbus.Models;

namespace OperaMaster.ViewModel;

public partial class LaserParameterViewModel(IEModbusFactory factory, ModbusMasterOptions opt) : ViewModelBase
{
    private readonly IModbusMasterClient _master = factory.CreateTcpMaster(opt.Name);

    [RelayCommand]
    private async Task SetParamter(int deviceid)
    {

    }
}
