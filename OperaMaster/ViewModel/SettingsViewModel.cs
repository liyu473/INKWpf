using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using iNKORE.UI.WPF.Modern;
using OperaMaster.Properties;
using System.Reflection;
using System.Windows.Media;

namespace OperaMaster.ViewModel;

// 背景类型变更消息
public record BackdropChangedMessage(string BackdropType);

// 导航位置变更消息
public record NavPanelModeChangedMessage(string Mode);

public partial class SettingsViewModel : ViewModelBase
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
    public SettingsViewModel()
    {
        SelectedColor = (Color)ColorConverter.ConvertFromString(Settings.Default.AccentColor);

        SelectedThemeIndex = Settings.Default.ThemeMode switch
        {
            "Light" => 0,
            "Dark" => 1,
            _ => 2
        };

        SelectedBackdropIndex = Settings.Default.BackdropType switch
        {
            "Mica" => 0,
            "Acrylic10" => 1,
            _ => 0
        };

        SelectedNavModeIndex = Settings.Default.NavPanelMode switch
        {
            "Left" => 0,
            "Top" => 1,
            _ => 0
        };
    }

    [ObservableProperty]
    public partial Color SelectedColor { get; set; }

    [ObservableProperty]
    public partial int SelectedThemeIndex { get; set; }

    [ObservableProperty]
    public partial int SelectedBackdropIndex { get; set; }

    [ObservableProperty]
    public partial int SelectedNavModeIndex { get; set; }

    partial void OnSelectedColorChanged(Color value)
    {
        ThemeManager.Current.AccentColor = value;
        Settings.Default.AccentColor = value.ToString();
        Settings.Default.Save();
    }

    partial void OnSelectedThemeIndexChanged(int value)
    {
        var (theme, mode) = value switch
        {
            0 => (ApplicationTheme.Light as ApplicationTheme?, "Light"),
            1 => (ApplicationTheme.Dark as ApplicationTheme?, "Dark"),
            _ => (null, "Default")
        };

        ThemeManager.Current.ApplicationTheme = theme;
        Settings.Default.ThemeMode = mode;
        Settings.Default.Save();
    }

    partial void OnSelectedBackdropIndexChanged(int value)
    {
        var backdropType = value switch
        {
            0 => "Mica",
            1 => "Acrylic10",
            _ => "Mica"
        };

        Settings.Default.BackdropType = backdropType;
        Settings.Default.Save();

        WeakReferenceMessenger.Default.Send(new BackdropChangedMessage(backdropType));
    }

    partial void OnSelectedNavModeIndexChanged(int value)
    {
        var mode = value switch
        {
            0 => "Left",
            1 => "Top",
            _ => "Left"
        };

        Settings.Default.NavPanelMode = mode;
        Settings.Default.Save();

        WeakReferenceMessenger.Default.Send(new NavPanelModeChangedMessage(mode));
    }

    /// <summary>
    /// 程序集名称
    /// </summary>
    public string AppName => _assembly.GetName().Name ?? string.Empty;

    /// <summary>
    /// 版本号
    /// </summary>
    public string Version => _assembly.GetName().Version?.ToString() ?? string.Empty;
}
