using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http.Headers;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context; 

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context=context;
    }

    [HttpGet("")]  
    public IActionResult Index()
    {
        List<Dish> Dishes=_context.Dishes.ToList();
        return View(Dishes);
    }
    [HttpGet("dishes/new")]

    public IActionResult Create ()
    {
        return View("CreateDish");
    }

    [HttpPost("dishes/create")]

    public IActionResult CreateDish(Dish dish)
    {
        if(ModelState.IsValid)
        {
        _context.Dishes.Add(dish);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        else 
        {
            return View();
        }

    }

    [HttpGet("dishes/{id}")]

    public IActionResult OneDish (int id)
    {
        Dish dish=_context.Dishes.FirstOrDefault(d=>d.DishId==id);
        Console.WriteLine("***************************");
        Console.WriteLine(dish.Name);
        return View(dish);
    }

    [HttpPost("dishes/{id}/destroy")]

    public IActionResult Delete(int id)
    {
        Dish? dish =_context.Dishes.SingleOrDefault(d=>d.DishId==id);
        _context.Dishes.Remove(dish);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }


    [HttpGet("dishes/{id}/edit")]

        public IActionResult Edit (int id)
    {
        Dish dish =_context.Dishes.FirstOrDefault(d=>d.DishId==id);

        return View(dish);
    }


    [HttpPost("dishes/{id}/update")]

    public IActionResult UpdateDish(Dish dish,int  id)
    { Dish? ToUpdateDish=_context.Dishes.FirstOrDefault(d=>d.DishId==id);
        if(ToUpdateDish==null)
        {
            RedirectToAction("Index");
        }
        if(ModelState.IsValid)
        {
       
            ToUpdateDish.Chef=dish.Chef;
            ToUpdateDish.Name=dish.Name;
            ToUpdateDish.Calories=dish.Calories;
            ToUpdateDish.Tastiness=dish.Tastiness;
            ToUpdateDish.Description=dish.Description;
            ToUpdateDish.UpdatedAt=DateTime.Now;
            _context.SaveChanges();

        return RedirectToAction("Index");
        }
        else 
        {
            return View("Edit",ToUpdateDish);
        }

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
