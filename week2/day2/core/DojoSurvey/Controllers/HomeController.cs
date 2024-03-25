using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
namespace CodingSurvey.Controllers;
public class HomeController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult  Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string name,string location,string ln,string comment)
    {
        Console.WriteLine($"My name was: {name}");

        Console.WriteLine($"My number was: {location}");
        Console.WriteLine($"My number was: {ln}");
        Console.WriteLine($"My number was: {comment}");
        return RedirectToAction("Result", new {name,location,ln,comment});
    }

    [HttpGet("results")]

    public ViewResult Result(string name,string location,string ln,string comment)
    {
        ViewBag.Name=name;
        ViewBag.Location=location;
        ViewBag.language=ln;
        ViewBag.Comment=comment;
        return View();
    }

}
