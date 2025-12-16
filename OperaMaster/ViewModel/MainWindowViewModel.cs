using CommunityToolkit.Mvvm.ComponentModel;
using iNKORE.UI.WPF.Modern.Controls;
using OperaMaster.View;

namespace OperaMaster.ViewModel;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Header))]
    public partial object? Page { get; set; }

    public string? Header => Page?.ToString();

    [ObservableProperty]
    public partial NavigationViewPaneDisplayMode NavPanelMode { get; set; } 

    public void NavigateTo(string tag)
    {
        Page = tag switch
        {
            "LaserParameter" => App.GetService<LaserParameterView>(),
            "Settings" => App.GetService<SettingsView>(),
            _ => Page
        };
    }
}
