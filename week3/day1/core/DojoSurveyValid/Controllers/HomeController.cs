using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValid.Models;
using System.Runtime.InteropServices;

namespace DojoSurveyValid.Controllers;

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

    [HttpPost("process")]
    public IActionResult Process(Student student) // updated
    {    

        if(ModelState.IsValid)
        {
        
        return View("Process",student);
        }
        else 
        {
           return View("Index");
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
