using System.Windows;
using iNKORE.UI.WPF.Modern.Controls;
using iNKORE.UI.WPF.Modern.Media.Animation;
using OperaMaster.Service;
using OperaMaster.ViewModel;

namespace OperaMaster.View;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _vm;
    private readonly NavigateServer _nav;

    public MainWindow(MainWindowViewModel vm, NavigateServer nav)
    {
        InitializeComponent();
        DataContext = vm;
        _vm = vm;
        _nav = nav;
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
                _vm.Page = page; 
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
