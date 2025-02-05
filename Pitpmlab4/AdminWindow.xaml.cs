using System.Windows;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public partial class AdminWindow : Window
{
    private readonly Services _service;
    public AdminWindow()
    {
        InitializeComponent();
        _service = new Services();
        ProductList.ItemsSource = _service.GetProducts();
    }

    public void View()
    {
        ProductList.ItemsSource = _service.GetProducts();
    }

    private void B_Delete_OnClick(object sender, RoutedEventArgs e)
    {
        var ProductRemoving = ProductList.SelectedItem as Product;
        if (MessageBox.Show($"Accept deletion?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) !=
            MessageBoxResult.Yes) return;
        _service.DeleteProduct(ProductRemoving);
        MessageBox.Show("Product deleted");
        View();
    }

    private void B_Edit_OnClick(object sender, RoutedEventArgs e)
    {
        var productEditing = ProductList.SelectedItem;
        var pm = new ProductManipulation(productEditing as Product);
        pm.Show();
        this.Close();
    }

    private void B_AddProduct_OnClick(object sender, RoutedEventArgs e)
    {
        var pm = new ProductManipulation();
        pm.Show();
        Close();
    }
}