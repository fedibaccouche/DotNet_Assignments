using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductNCategories.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;



namespace ProductNCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private MyContext _context; 

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {

        MyViewModel myViewModel = new MyViewModel
        {
            AllProducts=_context.Products.ToList()
        };
        return View(myViewModel);
    }

    
    [HttpPost("products/create")]

    public IActionResult CreateProduct(Product product)
    {
        if(ModelState.IsValid)
        {
        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else 
        {
        MyViewModel myViewModel = new MyViewModel
        {
            AllProducts=_context.Products.ToList()
        };
            return View("Index",myViewModel);
        }

    }

    [HttpGet("/categories")]

    public IActionResult Categories()
    {

        MyViewModel myViewModel = new MyViewModel
        {
            AllCategories=_context.Categories.ToList()
        };
        return View(myViewModel);
    }

        [HttpPost("categories/create")]

        public IActionResult CreateCategory(Categorie categorie)
    {
        if(ModelState.IsValid)
        {
        _context.Categories.Add(categorie);
        _context.SaveChanges();
        return RedirectToAction("Categories");
        }
        else 
        {
        MyViewModel myViewModel = new MyViewModel
        {
            AllCategories=_context.Categories.ToList()
        };
            return View("Categories",myViewModel);
        }

    }

    [HttpGet("/products/{id}/edit")]

    public IActionResult OneProduct(int id)
    {

        Product? product=_context.Products.Include(a => a.Associations).ThenInclude(c =>c.Categorie).FirstOrDefault(p => p.ProductId==id);
        Console.WriteLine("+++++++++");
        Console.WriteLine(product.Name);
        List<Categorie> FilteredCategories=_context.Categories.ToList();

        foreach(Association a in product.Associations)
        {
            FilteredCategories.Remove(a.Categorie);
        }
   

             MyViewModel myViewModel = new MyViewModel
        {
            Product=product,
            AllCategories=FilteredCategories
        };
        return View(myViewModel);
    }

[HttpPost("/products/category/create")]
   public IActionResult AddCategoryToProduct()
   {
     int CategorieId = Int32.Parse(Request.Form["SelectedCategory"]);
     int ProductId=Int32.Parse(Request.Form["ProductId"]);

     Console.WriteLine("+++++++++++++++++++++++++");
     Console.WriteLine(CategorieId);
     Console.WriteLine(ProductId);
     Categorie? c = _context.Categories.FirstOrDefault(c=>c.CategorieId==CategorieId);
     Product? p = _context.Products.FirstOrDefault(p=>p.ProductId==ProductId);
     Association a = new Association{
        ProductId=ProductId,
        CategorieId=CategorieId,
     };
        _context.Associations.Add(a);
        
        _context.SaveChanges();
     return RedirectToAction("OneProduct",new {id=ProductId});
   }



    [HttpGet("/categories/{id}/edit")]

    public IActionResult OneCategorie(int id)
    {

        Categorie? categorie=_context.Categories.Include(a => a.Associations).ThenInclude(c =>c.Product).FirstOrDefault(p => p.CategorieId==id);
     
        List<Product> FilteredProducts=_context.Products.ToList();
       
        foreach(Association a in categorie.Associations)
        {
               Console.WriteLine("+++++++++");
               Console.WriteLine(a.Product.Name);
               FilteredProducts.Remove(a.Product);
        }

        foreach(Product p in FilteredProducts)
        {
             Console.WriteLine("***************");
            Console.WriteLine(p.Name);
            
        }

        Console.WriteLine(FilteredProducts.Count);
   

             MyViewModel myViewModel = new MyViewModel
        {
            Categorie=categorie,
            AllProducts=FilteredProducts
        };
        return View(myViewModel);
    }


    [HttpPost("/categories/product/create")]
   public IActionResult AddProductToCategory()
   {
     int ProductId = Int32.Parse(Request.Form["SelectedProduct"]);
     int CategorieId=Int32.Parse(Request.Form["CategorieId"]);

     Console.WriteLine("+++++++++++++++++++++++++");
     Console.WriteLine(ProductId);
     Console.WriteLine(CategorieId);
     Categorie? c = _context.Categories.FirstOrDefault(c=>c.CategorieId==CategorieId);
     Product? p = _context.Products.FirstOrDefault(p=>p.ProductId==ProductId);
     Association a = new Association{
        ProductId=ProductId,
        CategorieId=CategorieId,
     };
        _context.Associations.Add(a);
        
        _context.SaveChanges();
     return RedirectToAction("OneCategorie",new {id=CategorieId});
   }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
