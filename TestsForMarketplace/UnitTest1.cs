namespace TestsForMarketplace;
using Pitpmlab4;
using Pitpmlab4.Database.ssms.models;

public class Tests
{
    private readonly Random _random = new();
    private readonly Pitpmlab4.Services service = new();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var expected = new Product
        {
            Name = "Test Product",
            Cost = _random.Next(0, 100),
            ImagePath = "test.png",
        };
        
        var id = service.AddNewProduct(expected);
        if (id == 0)
            Assert.Fail();
        
        var actual = service.GetProductById(expected.Id);
        
        if(actual == null)
            Assert.Fail();
        
        Assert.AreEqual(expected.Name, actual.Name);
        
        service.DeleteProduct(actual);
    }

    [Test]
    public void Test2()
    {
        string name = "New name";
        var product = new Product
        {
            Cost = 1,
            ImagePath = "test.png",
            Name = "Test Product",
        };

        var id = service.AddNewProduct(product);
        if (id == 0)
        {
            Assert.Fail();
        }
        
        var productForUpdate = service.GetProductById(id);
        if (productForUpdate is null)
        {
            Assert.Fail();
        }

        var updid = service.EditProduct(productForUpdate, name, productForUpdate.Cost, productForUpdate.ImagePath);
        if (updid == 0)
        {
            Assert.Fail();
        }
        
        Assert.AreEqual(id, updid);
        
        var actual = service.GetProductById(productForUpdate.Id);
        if (actual is null)
        {
            Assert.Fail();
        }

        Assert.AreEqual(productForUpdate.Id, actual.Id);
        Assert.AreEqual(actual.Name, name);

        service.DeleteProduct(actual);
    }

    [Test]
    public void Test3()
    {
        var product = new Product
        {
            Cost = 1,
            ImagePath = "test.png",
            Name = "Test Product",
        };

        var id = service.AddNewProduct(product);
        if (id == 0)
        {
            Assert.Fail();
        }
        
        var productForDelete = service.GetProductById(id);
        if (productForDelete is null)
        {
            Assert.Fail();
        }

        var delid = service.DeleteProduct(productForDelete);
        if (delid == 0)
        {
            Assert.Fail();
        }
        
        Assert.AreEqual(id, delid);

        var actual = service.GetProductById(productForDelete.Id);

        Assert.IsNull(actual);

    }
}