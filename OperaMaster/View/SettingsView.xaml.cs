using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using iNKORE.UI.WPF.Modern;
using OperaMaster.Properties;

namespace OperaMaster.View;

public partial class SettingsView : UserControl
{
    private bool _isInitializing = true;

    public SettingsView()
    {
        InitializeComponent();
        LoadSettings();
        _isInitializing = false;
    }

    private void LoadSettings()
    {
        // 加载主题模式
        if (Settings.Default.IsDarkTheme)
        {
            DarkRadio.IsChecked = true;
        }
        else
        {
            LightRadio.IsChecked = true;
        }

        // 加载主题色
        var color = (Color)ColorConverter.ConvertFromString(Settings.Default.AccentColor);
        ColorPicker.SelectedColor = color;
    }

    private void LightTheme_Click(object sender, RoutedEventArgs e)
    {
        ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
        Settings.Default.IsDarkTheme = false;
        Settings.Default.Save();
    }

    private void DarkTheme_Click(object sender, RoutedEventArgs e)
    {
        ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
        Settings.Default.IsDarkTheme = true;
        Settings.Default.Save();
    }

    private void ColorPicker_ColorChanged(object sender, RoutedEventArgs e)
    {
        if (_isInitializing) return;

        var color = ColorPicker.SelectedColor;
        ThemeManager.Current.AccentColor = color;

        Settings.Default.AccentColor = color.ToString();
        Settings.Default.Save();
    }
}
