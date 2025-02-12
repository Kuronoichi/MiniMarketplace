using System.IO;
using System.Windows;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public partial class UserWindow : Window
{
    private readonly Services _service;
    private readonly List<Product>? _products;
    public UserWindow()
    {
        InitializeComponent();
        _service = new Services();
    }

    private void UserWindow_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        ProductCard.ItemsSource = _service.GetProducts();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        new LoginWindow().Show();
        Close();
    }
}