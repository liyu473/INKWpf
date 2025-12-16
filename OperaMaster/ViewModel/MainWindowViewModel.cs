using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using iNKORE.UI.WPF.Modern.Controls;
using OperaMaster.Properties;
using OperaMaster.Service;

namespace OperaMaster.ViewModel;

public partial class MainWindowViewModel : ViewModelBase
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
    private readonly NavigateServer _nav;

    public MainWindowViewModel(NavigateServer nav)
    {
        _nav = nav;
        Page = nav.GetPageByTag("LaserParameter");

        // 初始化导航模式
        NavPanelMode = Settings.Default.NavPanelMode switch
        {
            "Top" => NavigationViewPaneDisplayMode.Top,
            _ => NavigationViewPaneDisplayMode.Left
        };

        // 监听导航模式变更
        WeakReferenceMessenger.Default.Register<NavPanelModeChangedMessage>(this, (r, m) =>
        {
            NavPanelMode = m.Mode switch
            {
                "Top" => NavigationViewPaneDisplayMode.Top,
                _ => NavigationViewPaneDisplayMode.Left
            };
        });
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Header))]
    public partial object? Page { get; set; }

    public string? Header => Page is { } page ? _nav.GetHeaderByType(page.GetType()) : null;

    [ObservableProperty]
    public partial NavigationViewPaneDisplayMode NavPanelMode { get; set; }

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
