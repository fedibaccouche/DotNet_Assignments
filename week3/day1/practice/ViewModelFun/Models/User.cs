// Notice the use of the "Models" tag the same way we put "Controllers" in our Controller file
#pragma warning disable CS8618

namespace ViewModelFun.Models;
public class User    
{    
    // We must put {get;set;} after all our properties
    // This will give ASP.NET Core the permissions it needs to modify the values    
    public string FirstName {get;set;}        
    public string LastName {get;set;}        
      
}
