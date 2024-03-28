#pragma warning disable CS8618
namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;


public class User{
    [Required]
    public string Name {get;set;}
    [Required]
[ValidationDate]
[DataType(DataType.Date)]
    public DateTime date {get;set;}
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

