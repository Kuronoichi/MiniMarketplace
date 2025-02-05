using System.IO;
using System.Windows;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public partial class UserWindow : Window
{
    private readonly Services _service;
    private List<Product>? _products;
    public UserWindow()
    {
        InitializeComponent();
        _service = new Services();
        _products = _service.GetProducts();
    }

    private void UserWindow_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        ProductCard.ItemsSource = _products;
    }

    private void UserWindow_OnClosed(object? sender, EventArgs e)
    {
        new LoginWindow().Show();
    }
}