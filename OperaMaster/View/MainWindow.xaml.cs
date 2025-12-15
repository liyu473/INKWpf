using HandyControl.Tools;

namespace OperaMaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetWindowDefaultStyle();
        }
    }
}