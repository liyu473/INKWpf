using CommunityToolkit.Mvvm.ComponentModel;
using OperaMaster.View;

namespace OperaMaster.ViewModel;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Page = App.GetService<LaserParameterView>();
    }

    [ObservableProperty]
    public partial object Page { get; set; }
}
