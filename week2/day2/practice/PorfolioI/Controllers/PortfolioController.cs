using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers;
public class PorfolioController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "This is my index";
    }
    
    // Route declaration Option B
    // This will go to "localhost:5XXX/user/more"
    [HttpGet("projects")]
    public string projects()
    {
        return "These are my projects";
    }
    
        [HttpGet("contact")]
    public string contact()
    {
        return "This is my contact";
    }
  
}
