using System.Windows;

namespace Pitpmlab4;

public partial class RegisterWindow : Window
{
    private readonly Services _service;
    public RegisterWindow()
    {
        InitializeComponent();
        _service = new Services();
    }

    private void B_Login_OnClick(object sender, RoutedEventArgs e)
    {
        new LoginWindow().Show();
        this.Close();
    }

    private void B_Registration_OnClick(object sender, RoutedEventArgs e)
    {
        _service.Register(tb_login.Text, tb_Password.Password);
        MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        new LoginWindow().Show();
        this.Close();
    }
}