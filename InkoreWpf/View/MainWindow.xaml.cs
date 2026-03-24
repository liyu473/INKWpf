using CommunityToolkit.Mvvm.Messaging;
using iNKORE.UI.WPF.Modern.Controls;
using iNKORE.UI.WPF.Modern.Controls.Helpers;
using iNKORE.UI.WPF.Modern.Helpers.Styles;
using iNKORE.UI.WPF.Modern.Media.Animation;
using InkoreWpf.Properties;
using InkoreWpf.Service;
using InkoreWpf.ViewModel;
using LyuExtensions.Aspects;
using System.Windows;

namespace InkoreWpf.View;


[Singleton]
public partial class MainWindow : Window
{
    [Inject]
    private readonly MainWindowViewModel _vm;

    [Inject]
    private readonly NavigateServer _nav;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _vm;

        ApplyBackdropType(Settings.Default.BackdropType);

        WeakReferenceMessenger.Default.Register<BackdropChangedMessage>(this, (r, m) =>
        {
            ApplyBackdropType(m.BackdropType);
        });
    }

    private void ApplyBackdropType(string backdropType)
    {
        var type = backdropType switch
        {
            "Acrylic10" => BackdropType.Acrylic10,
            _ => BackdropType.Mica
        };

        WindowHelper.SetSystemBackdropType(this, type);
    }

    private void NavView_SelectionChanged(
        NavigationView sender,
        NavigationViewSelectionChangedEventArgs args
    )
    {
        if (args.SelectedItem is NavigationViewItem { Tag: string tag })
        {
            var page = _nav.GetPageByTag(tag);
            if (page is not null)
            {
                ContentFrame.Navigate(page, null, new DrillInNavigationTransitionInfo());

            }
        }
    }

    private void NvSample_BackRequested(
        NavigationView sender,
        NavigationViewBackRequestedEventArgs args
    )
    {
        if (ContentFrame.CanGoBack)
            ContentFrame.GoBack();
    }
}
