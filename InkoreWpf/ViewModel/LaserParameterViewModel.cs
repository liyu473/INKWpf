using CommunityToolkit.Mvvm.Input;
using LyuEModbus.Abstractions;
using LyuEModbus.Models;

namespace InkoreWpf.ViewModel;

public partial class LaserParameterViewModel(IEModbusFactory factory, ModbusMasterOptions opt)
    : ViewModelBase
{
    private readonly IModbusMasterClient _master =
        factory.GetMaster(opt.Name)
        ?? throw new InvalidOperationException($"Modbus master '{opt.Name}' not found.");

    [RelayCommand]
    private async Task SetParamter(int deviceid) { }
}
