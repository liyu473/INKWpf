using OperaMaster.ViewModel;
using System.Windows.Controls;

namespace OperaMaster.View;

/// <summary>
/// SettingsView.xaml 的交互逻辑
/// </summary>
public partial class SettingsView : UserControl
{
    private readonly SettingsViewModel _vm;
    public SettingsView(SettingsViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
        _vm = vm;
    }
}
