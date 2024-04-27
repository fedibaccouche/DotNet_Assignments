#pragma warning disable CS8618
// using statements and namespace go here

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace WeddingPlanner.Models;
public class LoginUser
{
    
    [Required] 
    [Email]   
    public string LogInEmail { get; set; }    
    [Required] 
    [DataType(DataType.Password)]
    public string LogInPassword { get; set; } 
}


public class EmailAttribute : ValidationAttribute
{
        static bool IsValidEmail(string email)
    {
        // Regular expression for basic email validation
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Match the pattern against the email address
        Match match = Regex.Match(email, pattern);

        // Return true if the email matches the pattern, false otherwise
        return match.Success;
    }
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   

        if (value==null)
        {
            return new ValidationResult("Email is required");
        } 
        
        if (!IsValidEmail((string) value))
        {
            return new ValidationResult("Your Email is not formatted correctly");
        } else {
            return ValidationResult.Success;
        }
    }
}