// Notice the use of the "Models" tag the same way we put "Controllers" in our Controller file
#pragma warning disable CS8618
namespace DojoSurveyModel.Models;
public class Student    
{    
    // We must put {get;set;} after all our properties
    // This will give ASP.NET Core the permissions it needs to modify the values    
    public string name {get;set;}        
    public string location {get;set;}        
    public string ln {get;set;}
    public string comment {get;set;}    
}
