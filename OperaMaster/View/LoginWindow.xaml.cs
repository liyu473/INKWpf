using System.Windows;

namespace OperaMaster.View;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();

#if DEBUG
        UsernameBox.Text = "admin";
        PasswordBox.Password = "123456";
#endif
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameBox.Text;
        var password = PasswordBox.Password;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            ErrorText.Text = "请输入用户名和密码";
            return;
        }

        if (username == "admin" && password == "123456")
        {
            DialogResult = true;
            Close();
        }
        else
        {
            ErrorText.Text = "用户名或密码错误";
        }
    }
}
