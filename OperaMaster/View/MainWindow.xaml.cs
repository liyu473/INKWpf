using System.Windows;
using iNKORE.UI.WPF.Modern.Controls;
using OperaMaster.ViewModel;

namespace OperaMaster.View;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _vm;

    public MainWindow(MainWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
        _vm = vm;
    }

    private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem is NavigationViewItem item && item.Tag is string tag)
        {
            _vm.NavigateTo(tag);
        }
    }
}
