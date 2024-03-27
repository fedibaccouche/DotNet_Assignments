// Notice the use of the "Models" tag the same way we put "Controllers" in our Controller file
#pragma warning disable CS8618
namespace DojoSurveyValid.Models;
using System.ComponentModel.DataAnnotations;
public class Student    
{    
    // We must put {get;set;} after all our properties
    // This will give ASP.NET Core the permissions it needs to modify the values    

    [Required]
    [MinLength(2)]   
    public string name {get;set;}   

    [Required]   
    // We can stack annotations to apply multiple requirements to one property
    // In this case, a Username is required but must also be at least 3 characters long     
    public string location {get;set;}     

    [Required]   
    public string ln {get;set;}

    [MinLength(20)]
    public string? comment {get;set;}    
}
