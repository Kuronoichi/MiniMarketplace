using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pitpmlab4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    private readonly Services _services;
    
    public LoginWindow()
    {
        InitializeComponent();
        _services = new Services();
    }

    private void B_Login_OnClick(object sender, RoutedEventArgs e)
    {
        var user = _services.Login(tb_login.Text, tb_Password.Password);
        if (user == null)
            MessageBox.Show("Wrong username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        else if (_services.IsAdmin(user.Login))
        {
            MessageBox.Show("You are logged in", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            new AdminWindow().Show();
            this.Close();
        }
        else
        {
            MessageBox.Show("You are logged in", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            new UserWindow().Show();
            this.Close();
        }
    }

    private void B_Registration_OnClick(object sender, RoutedEventArgs e)
    {
        new RegisterWindow().Show();
        this.Close();
    }
}