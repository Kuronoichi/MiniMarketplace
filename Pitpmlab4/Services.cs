using System.Windows;
using Pitpmlab4.Database.ssms;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public class Services
{
    private readonly SsmsContext _context;

    public Services()
    {
        _context = new SsmsContext();
    }

    public User? Login(string Login, string Password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == Login && u.Password == Password);
        return user;
    }

    public void Register(string Login, string Password)
    {
        var user = new User();
        
        user.Login = Login;
        user.Password = Password;
        user.UserRole = 1;
        
        if(user != null && !_context.Users.Any(u => u.Login == Login))
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public bool IsAdmin(string Login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == Login);
        if (user.UserRole == 2)
            return true;
        else
            return false;
    }

    public void AddNewProduct(Product product)
    {
        if (product != null)
        {
            _context.Products.Add(product);
                    _context.SaveChanges();
        }
        else
        {
            MessageBox.Show("Product not found", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }
        
    }

    public void EditProduct(Product product, string Name, int Cost, string ImagePath)
    {
        product.Name = Name;
        product.Cost = Cost;
        product.ImagePath = ImagePath;
        
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(List<Product> product)
    {
        _context.Products.RemoveRange(product);
        _context.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

}