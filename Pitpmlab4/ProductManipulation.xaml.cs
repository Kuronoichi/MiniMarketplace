using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public partial class ProductManipulation : Window
{
    private readonly Product _product;
    private readonly Services _services;
    private bool edition = false;
    
    public ProductManipulation()
    {
        InitializeComponent();
        _services = new Services();
        _product = new Product();
        edition = true;
    }

    public ProductManipulation(Product product)
    {
        InitializeComponent();
        _services = new Services();
        _product = product;
        edition = false;
        tb_ImagePath.Text = product.ImagePath;
        tb_Name.Text = product.Name;
        tb_Price.Text = product.Cost.ToString();
    }

    private void B_SelectImage_OnClick(object sender, RoutedEventArgs e)
    {
        var ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == true)
        {

            File.Copy(ofd.FileName,
                Path.Combine(@"C:\Users\user\RiderProjects\Pitpmlab4\Pitpmlab4\Static", Path.GetFileName(ofd.FileName)), true);
            tb_ImagePath.Text = Path.Combine(@"C:\Users\user\RiderProjects\Pitpmlab4\Pitpmlab4\Static", Path.GetFileName(ofd.FileName));
            if (_services.GetProducts().Any(m => m.ImagePath == tb_ImagePath.Text))
            {
                MessageBox.Show("Image is used", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tb_ImagePath.Text = string.Empty;
            }

           
        }
    }

    private void B_EndManipulation_OnClick(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(tb_Name.Text) && !string.IsNullOrEmpty(tb_Price.Text) && !string.IsNullOrEmpty(tb_ImagePath.Text) && int.TryParse(tb_Price.Text, out var cost))
        {
            if (edition == false)
            {
                _services.EditProduct(_product.Id, tb_Name.Text, cost, tb_ImagePath.Text);
                Close();
            }
            else
            {
                if (_services.GetProducts().All(p => p.Name != tb_Name.Text))
                {
                    _product.Cost = cost;
                    _product.Name = tb_Name.Text;
                    _product.ImagePath = tb_ImagePath.Text;
                    _services.AddNewProduct(_product);
                }
                else
                {
                    MessageBox.Show("Product name is used", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Close();
            }
        }
        else
            MessageBox.Show("Failed to do manipulation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}