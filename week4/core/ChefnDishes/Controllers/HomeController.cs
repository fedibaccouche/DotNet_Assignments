using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefnDishes.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ChefnDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
     private MyContext _context; 

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context=context;
    }
    [HttpGet("/")]
   public IActionResult Index()
    {   
        MyViewModel mymodel = new MyViewModel
        {
            AllChefs=_context.Chefs.Include(c=>c.AllDishes).ToList(),

        };
        return View(mymodel);
    }

    [HttpGet("/chefs/new")]
   public IActionResult ChefView()
    {   
     
        return View("CreateChef");
    }

    [HttpPost("chefs/create")]

    public IActionResult CreateChef(Chef chef)
    {
        if(ModelState.IsValid)
        {
        
        _context.Chefs.Add(chef);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else 
        {
            return View();
        }

    }

    [HttpGet("/dishes/new")]
   public IActionResult DishView()
    {   
        ViewBag.AllChefs=_context.Chefs.ToList();
     
        return View();
    }

     [HttpPost("dishes/create")]

       public IActionResult CreateDish(Dish dish)
    {
        
        if(ModelState.IsValid)
        {
            Console.WriteLine("I'm here inside validation dish");
        
        _context.Dishes.Add(dish);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else 
        {
            ViewBag.AllChefs=_context.Chefs.ToList();
            return View("DishView");
        }

    }
    [HttpGet("/dishes")]
      public IActionResult AllDishes()
    {   Console.WriteLine("*************** I'm here now");
             MyViewModel mymodel = new MyViewModel
        {
            AllDishes=_context.Dishes.Include(d=>d.ChefCreator).ToList(),

        };
     
        return View(mymodel);
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
