using CommunityToolkit.Mvvm.ComponentModel;
using iNKORE.UI.WPF.Modern.Controls;
using OperaMaster.Service;

namespace OperaMaster.ViewModel;

public partial class MainWindowViewModel(NavigateServer nav) : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Header))]
    public partial object? Page { get; set; } = nav.GetPageByTag("LaserParameter");

    public string? Header => Page is { } page ? nav.GetHeaderByType(page.GetType()) : null;

    [ObservableProperty]
    public partial NavigationViewPaneDisplayMode NavPanelMode { get; set; } = NavigationViewPaneDisplayMode.Auto;
}
