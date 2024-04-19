using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginRegistration.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;





namespace LoginRegistration.Controllers;

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
        return View();
    }

    [HttpPost("users/create")]

    public IActionResult CreateUser(User user)
    { Console.WriteLine("**********************");
            Console.WriteLine("I'm here");
        if(ModelState.IsValid)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("I'm here inside modelstate");

        PasswordHasher<User> Hasher = new PasswordHasher<User>();   
            // Updating our newUser's password to a hashed version         
        user.Password = Hasher.HashPassword(user, user.Password); 
        _context.Users.Add(user);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("UserId", user.UserId);
        return RedirectToAction("Success");
        }
        else 
        {
            return View("Index");
        }

    }

    [HttpPost("login")]

        public IActionResult LoginUser(LoginUser userSubmission)
    {
        if(ModelState.IsValid)
        {
        // If initial ModelState is valid, query for a user with the provided email        
        User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LogInEmail);        
        // If no user exists with the provided email        
        if(userInDb == null)        
        {            
            // Add an error to ModelState and return to View!            
            ModelState.AddModelError("LogInEmail", "Invalid Email/Password");            
            return View("Index");        
        }   
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>(); 
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogInPassword);                                    // Result can be compared to 0 for failure        
        if(result == 0)        
        {            
           ModelState.AddModelError("LogInEmail", "Invalid Email/Password");
           ModelState.AddModelError("LogInPassword", "Invalid Email/Password");  
           return View("Index"); 
        }
        else {
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            
            return RedirectToAction("Success");
        }
        }
        else 
        {
            return View("Index");
        }

    }

    [SessionCheck]
    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View("Success");
    }




    // Name this anything you want with the word "Attribute" at the end
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}

    
    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
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
