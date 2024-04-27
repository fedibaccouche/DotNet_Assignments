using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Net.Http.Headers;


namespace WeddingPlanner.Controllers;

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
        HttpContext.Session.SetString("Name",user.FirstName);
        return RedirectToAction("Weddings");
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
            HttpContext.Session.SetString("Name",userInDb.FirstName);
            
            return RedirectToAction("Weddings");
        }
        }
        else 
        {
            return View("Index");
        }

    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [SessionCheck]
    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View();
    }

    // int? userId  {get  =>HttpContext.Session.GetInt32("UserId");}

    [SessionCheck]
    
    [HttpGet("/weddings")]
    

    public IActionResult Weddings()
    {   

         Console.WriteLine("++++++++++++++++++++");
         Console.WriteLine("9bal if");

        if(HttpContext.Session.GetInt32("UserId")!=null)
        {
            

            User user = _context.Users.FirstOrDefault(u => u.UserId==(int)HttpContext.Session.GetInt32("UserId"));
            
            Console.WriteLine("++++++++++++++++++++");
            Console.WriteLine(user);
            MyViewModel myViewModel=new MyViewModel()
            {
                User=user,
                AllWeddings=_context.Weddings
                                            .Include(w => w.Associations)            
                                            .ThenInclude(a => a.User).ToList()
            
            };

           
            


            return View(myViewModel);
        }
        
            
               return RedirectToAction("Index");
             
    }

    [SessionCheck]
    [HttpPost]
    public IActionResult RDV_Weddding(Association a)
    {
        Console.WriteLine(a.UserId);
        Console.WriteLine(a.WeddingId);
        _context.Associations.Add(a);
        _context.SaveChanges();
        
        MyViewModel myViewModel=new MyViewModel()
        {
            User=_context.Users.FirstOrDefault(u => u.UserId==a.UserId),
             AllWeddings=_context.Weddings
                                        .Include(w => w.Associations)            
                                        .ThenInclude(a => a.User).ToList()
           
        };
        return RedirectToAction("Weddings", myViewModel);
    }
    [SessionCheck]
    [HttpPost]
    public IActionResult UNRDV_Weddding(Association a)
    {
        Association associationToRemove = _context.Associations.SingleOrDefault(f => f.UserId == a.UserId && f.WeddingId == a.WeddingId)!;
        _context.Associations.Remove(associationToRemove);
        _context.SaveChanges();
              MyViewModel myViewModel=new MyViewModel()
        {
            User=_context.Users.FirstOrDefault(u => u.UserId==a.UserId),
             AllWeddings=_context.Weddings
                                        .Include(w => w.Associations)            
                                        .ThenInclude(a => a.User).ToList()
           
        };
        return RedirectToAction("Weddings",myViewModel);
    }

    [SessionCheck]
    [HttpGet("/weddings/new")]
    public IActionResult PlanWedding()
    {
       
        Console.WriteLine("***********************");
       

        return View();
    }
        

    [SessionCheck]
    [HttpPost("/weddings/create")]

    public IActionResult AddWedding(Wedding wedding)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if(ModelState.IsValid)
        {

        _context.Weddings.Add(wedding);
        _context.SaveChanges();
        

        Association a = new Association{
                                            UserId=(int)userId,
                                            WeddingId=wedding.WeddingId,
                                        };

        
        
        
        _context.Associations.Add(a);
        _context.SaveChanges();
        return RedirectToAction("OneWedding",new {id=wedding.WeddingId});
        }

        return View("PlanWedding");
    }


    [SessionCheck]
    [HttpGet("/weddings/{id}")]
    public IActionResult OneWedding(int id)
    {
        Wedding? wedding=_context.Weddings.
                                           Include(a => a.Associations)
                                           .ThenInclude(c =>c.User).FirstOrDefault(w => w.WeddingId==id);
        return View(wedding);
    }
    [SessionCheck]
    [HttpGet("weddings/{id}/destroy")]

    public IActionResult Delete(int id)
    {
        Wedding? wedding =_context.Weddings.SingleOrDefault(w=>w.WeddingId==id);

        _context.Weddings.Remove(wedding);

        List<Association> associations=_context.Associations.Where(a=>a.WeddingId==id).ToList();

        foreach(Association a in associations)
        {
            _context.Associations.Remove(a);
        }
        
        _context.SaveChanges();

        return RedirectToAction("Weddings");
    }





    public IActionResult Privacy()
    {
        return View();
    }

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
