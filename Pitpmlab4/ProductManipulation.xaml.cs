using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public partial class ProductManipulation : Window
{
    private Product _product;
    private readonly Services _services;
    
    public ProductManipulation()
    {
        InitializeComponent();
        _services = new Services();
        _product = new Product();
    }

    public ProductManipulation(Product product)
    {
        InitializeComponent();
        _services = new Services();
        _product = product;
        tb_ImagePath.Text = product.ImagePath;
        tb_Name.Text = product.Name;
        tb_Price.Text = product.Cost.ToString();
    }

    private void B_SelectImage_OnClick(object sender, RoutedEventArgs e)
    {
        var ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == true)
        {
            File.Copy(ofd.FileName, Path.Combine(@"C:\Users\user\RiderProjects\Pitpmlab4\Pitpmlab4\Static", Path.GetFileName(ofd.FileName)), true);
            tb_ImagePath.Text = Path.Combine(@"C:\Users\user\RiderProjects\Pitpmlab4\Pitpmlab4\Static", Path.GetFileName(ofd.FileName));
        }
    }

    private void B_EndManipulation_OnClick(object sender, RoutedEventArgs e)
    {
        int cost = 0;
        if (!string.IsNullOrEmpty(tb_Name.Text) && !string.IsNullOrEmpty(tb_Price.Text) && !string.IsNullOrEmpty(tb_ImagePath.Text) && int.TryParse(tb_Price.Text, out cost))
        if (_product.Name != null)
        {
            _services.EditProduct(_product, tb_Name.Text, cost, tb_ImagePath.Text);
            var aw = new AdminWindow();
            aw.Show();
            Close();
        }

        else
        {
            _product.Name = tb_Name.Text;
            _product.Cost = cost;
            _product.ImagePath = tb_ImagePath.Text;
            _services.AddNewProduct(_product);
            var aw = new AdminWindow();
            aw.Show();
            Close();
        }
    }

    
}