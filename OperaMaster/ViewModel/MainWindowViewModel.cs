using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using iNKORE.UI.WPF.Modern.Controls;
using OperaMaster.Service;

namespace OperaMaster.ViewModel;

public partial class MainWindowViewModel(NavigateServer nav) : ViewModelBase
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Header))]
    public partial object? Page { get; set; } = nav.GetPageByTag("LaserParameter");

    public string? Header => Page is { } page ? nav.GetHeaderByType(page.GetType()) : null;

    [ObservableProperty]
    public partial NavigationViewPaneDisplayMode NavPanelMode { get; set; } = NavigationViewPaneDisplayMode.Auto;

    /// <summary>
    /// 程序集名称
    /// </summary>
    public string AppName => _assembly.GetName().Name ?? string.Empty;

    /// <summary>
    /// 版本号
    /// </summary>
    public string Version => _assembly.GetName().Version?.ToString() ?? string.Empty;

    /// <summary>
    /// 窗口标题
    /// </summary>
    public string Title => $"{AppName} v{Version}";
}
