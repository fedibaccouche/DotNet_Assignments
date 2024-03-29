using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("submit")]
    public IActionResult Submit(string name)
    {   
        if (string.IsNullOrEmpty(name))
        {
            return View("Index");
        }
        else {
            HttpContext.Session.SetString("Name",name);
            HttpContext.Session.SetInt32("Number", 22);

            return RedirectToAction("Dashboard");

        }
    }
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
           return View();
    }

      [HttpGet("calculate")]
    public IActionResult Calculate(int parameter)
    {
        Console.WriteLine(parameter);
           return View("Dashboard");
    }

     [HttpPost("update")]
     public IActionResult Update(int number)
    {
        Console.WriteLine(number);

        int? n=HttpContext.Session.GetInt32("Number");
        if (number!=2)
        {
            n+=number;
        }
        else 
        {
            n=n*2;
        }

        HttpContext.Session.SetInt32("Number",(int) n);

           return View("Dashboard");
    }

     [HttpGet("logout")]
    public IActionResult Logout()
    {
       HttpContext.Session.Clear();
       HttpContext.Session.SetInt32("Number", 22);

       return RedirectToAction("Index");

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
