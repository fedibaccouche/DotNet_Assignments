using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers;
public class ListController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }
    
  
  
}
