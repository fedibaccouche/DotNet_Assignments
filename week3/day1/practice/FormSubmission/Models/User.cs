#pragma warning disable CS8618
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Security;
using System.Text.RegularExpressions;

using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models;

public class User {


    [Required]
     [MinLength(2)] 
    public string Name{get;set;}

    [Required(ErrorMessage ="The Email address field is required")]
    
    [Email]
    
    public string EmailAddress {get;set;}
    [Required]
    [ValidationDate]
    [DataType(DataType.Date)]
    public DateTime Date {get;set;}
    [Required]
    [MinLength(8)] 

    [DataType(DataType.Password)] 
    
    public string Password {get;set;}
    [Required]
    [ValidationOddNumber]
    public int FavNumber {get;set;}


}


public class ValidationDateAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   
         DateTime CurrentTime = DateTime.Now;
         Console.WriteLine(value);
        if (DateTime.Compare(CurrentTime, (DateTime)value)<0)
        {
            return new ValidationResult("The date entered need to be earlier than the current date");
        } else {
            return ValidationResult.Success;
        }
    }
}


public class ValidationOddNumberAttribute : ValidationAttribute
{
         static bool IsNotOdd(int n){
            if(n==0 | n==1)
            {return true;}
            else 
            {

            
            for(int i=2;i<n;i++)
            {
                if(n%i==0)
                {
                    return true;
                }
            }
            return false;
            }
            
         } 
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   
        
        if (IsNotOdd((int) value))
        {
            return new ValidationResult("Your favorite number must be a prime number");
        } else {
            return ValidationResult.Success;
        }
    }
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

        
        
        if (!IsValidEmail((string) value))
        {
            return new ValidationResult("Your Email is not formatted correctly");
        } else {
            return ValidationResult.Success;
        }
    }
}