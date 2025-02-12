using System.Windows;
using Pitpmlab4.Database.ssms;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4;

public class Services
{
    private readonly SsmsContext _context = new();

    public User? Login(string Login, string Password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == Login && u.Password == Password);
        return user;
    }

    public long Register(string Login, string Password)
    {
        var user = new User();
        
        user.Login = Login;
        user.Password = Password;
        user.UserRole = 1;
        
        if(user != null && !_context.Users.Any(u => u.Login == Login))
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user.Id;
            }
            catch
            {
                return 0;
            }
            
        }
        else
            return 0;

    }

    public bool IsAdmin(string Login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Login == Login);
        if (user.UserRole == 2)
            return true;
        else
            return false;
    }

    public long AddNewProduct(Product product)
    {
        if (product != null)
        {
            _context.Products.Add(product);
                    _context.SaveChanges();
                    return product.Id;
        }
        else
        {
            return 0;
        }
        
    }

    public long EditProduct(long Id, string Name, int? Cost, string ImagePath)
    {
        var product = _context.Products.Find(Id);
        product.Name = Name;
        product.Cost = Cost;
        product.ImagePath = ImagePath;
        try
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        catch
        {                
            return 0;
        }
        return product.Id;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProductById(long id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public long DeleteProduct(Product product)
    {
        if (!_context.Products.Any(p => p.Id == product.Id))
        {
            return 0;
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        return product.Id;
    }

    public User? GetUserByLogin(string login)
    {
        return _context.Users.FirstOrDefault(u => u.Login == login);
    }
    
    
}