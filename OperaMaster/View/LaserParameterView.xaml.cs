using OperaMaster.ViewModel;
using System.Windows.Controls;

namespace OperaMaster.View;

/// <summary>
/// LaserParameterView.xaml 的交互逻辑
/// </summary>
public partial class LaserParameterView : UserControl
{
    private readonly LaserParameterViewModel _vm;
    public LaserParameterView(LaserParameterViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
        _vm = vm;
    }
}
