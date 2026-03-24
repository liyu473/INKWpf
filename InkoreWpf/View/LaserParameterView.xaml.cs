using System.Windows.Controls;
using InkoreWpf.ViewModel;

namespace InkoreWpf.View;

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
