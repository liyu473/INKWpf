using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OperaMaster.ViewModel;

namespace OperaMaster.View;

public partial class SettingsView : UserControl
{
    public SettingsView(SettingsViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
