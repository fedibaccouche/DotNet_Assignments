using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
namespace PortfolioII.Controllers;
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
    
    // Route declaration Option B
    // This will go to "localhost:5XXX/user/more"
    [HttpGet("projects")]
    public ViewResult projects()
    {
        List<Dictionary<string,string>> l = new List<Dictionary<string,string>>();
        l.Add(new Dictionary<string,string>()
        {
            {"title","project1"},
            {"image","https://cdn.pixabay.com/photo/2016/03/29/08/48/project-1287781_640.jpg"},
            {"description","descrpition for project 1"}
        }
        );
               l.Add(new Dictionary<string,string>()
        {
            {"title","project2"},
            {"image","https://img.freepik.com/free-vector/project-management-business-process-planning-workflow-organization-colleagues-working-together-teamwork_335657-2469.jpg"},
            {"description","descrpition for project 2"}
        }
        );
                      l.Add(new Dictionary<string,string>()
        {
            {"title","project3"},
            {"image","https://img.freepik.com/free-vector/project-management-business-multitasking-concept-flat-line-art-icons_126523-2192.jpg"},
            {"description","descrpition for project 3"}
        }
        );

        ViewBag.ProjectsList=l;
        // ViewBag.Example = "Hello World!"; 
        
        return View("Project");
    }
    
        [HttpGet("contact")]
    public ViewResult contact()
    {
        return View("Contact");
    }
  
}
