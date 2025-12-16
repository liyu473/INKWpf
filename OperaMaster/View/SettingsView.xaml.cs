using System.Windows.Controls;
using OperaMaster.ViewModel;

namespace OperaMaster.View;

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
