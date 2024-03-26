using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string message="Hello from the other controller side";
        return View("Index",message);
    }


    [HttpGet("numbers")]

    public ViewResult Numbers()
    {
        List<int> numbers=new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(10);
        numbers.Add(21);
        numbers.Add(8);
        numbers.Add(7);
        numbers.Add(3);

        return View(numbers);


    }

    
    [HttpGet("user")]

    public ViewResult User()
    {
        User user=new User()
        {
            FirstName="Fedi",
            LastName="Baccouche"
            
        };

        return View(user);


    }




    [HttpGet("users")]

    public ViewResult Users()
    {   
        List<User> users=new List<User>();
        users.Add(new User()
        {
            FirstName="Neil",
            LastName="Gaiman"
            
        });
        
        users.Add(new User()
        {
            FirstName="Terry",
            LastName="pratchet"
        });

        users.Add(new User()
        {
            FirstName="Jane",
            LastName="Austen"
        });
        users.Add(new User()
        {
            FirstName="Stephen",
            LastName="King"
        });
        users.Add(new User()
        {
            FirstName="Mary",
            LastName="Shelley"
        });

        return View("Users",users);


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
