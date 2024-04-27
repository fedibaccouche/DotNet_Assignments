#pragma warning disable CS8618
// using statements and namespace go here

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace WeddingPlanner.Models;

public class Wedding {
    [Key]
    public int WeddingId{get;set;}

    public string WedderOne{get;set;}

    public string WedderTwo{get;set;}

    [DataType(DataType.Date)]
    [ValidationDate]

    public DateTime Date {get;set;}

    public string address {get;set;}

    public User? User {get;set;}

    public int UserId {get;set;}

    public List<Association> Associations{get;set;}=new List<Association>();

}

public class ValidationDateAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   
         DateTime CurrentTime = DateTime.Now;
         Console.WriteLine(value);
        if (DateTime.Compare(CurrentTime, (DateTime)value)>0)
        {
            return new ValidationResult("The date entered must be in the future");
        } else {
            return ValidationResult.Success;
        }
    }
}