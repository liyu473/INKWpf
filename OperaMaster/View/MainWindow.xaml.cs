using OperaMaster.ViewModel;

namespace OperaMaster.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        private readonly MainWindowViewModel _vm;
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            _vm = vm;
        }

        private void ClockButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClockPopup.IsOpen = true;
        }
    }
}