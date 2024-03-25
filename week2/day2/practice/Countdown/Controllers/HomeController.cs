using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc;
namespace Countdown.Controllers;
public class HomeController : Controller
{
    // Route declaration Option A
    // This will go to "localhost:5XXX"
    [HttpGet]
    [Route("")]
    public ViewResult  Index()
    {
        DateTime CurrentTime = DateTime.Now;
        DateTime Deadline = new DateTime(2024, 03,30 , 12, 0, 0);
        
        
        string CurrentTimeDate=CurrentTime.ToString("MMMM dd,yyyy");
        string CurrentTimeHour=CurrentTime.ToString("h:mm t");
       string  DeadlineDate=Deadline.ToString("MMMM dd,yyyy");
        string  DeadlineHour=Deadline.ToString("h:mm t");
        TimeSpan duration = Deadline-CurrentTime;
        string  d=$"{duration.Days} day(s), {duration.Hours} hour(s), {duration.Minutes} minute(s)";
        ViewBag.CurrentTimeDate = CurrentTimeDate;  
        ViewBag.CurrentTimeHour=CurrentTimeHour;
         ViewBag.DeadlineDate = DeadlineDate;  
        ViewBag.DeadlineHour=DeadlineHour;
         ViewBag.d=d;

        return View();
    }

}