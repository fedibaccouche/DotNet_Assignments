#pragma warning disable CS8618
namespace ChefnDishes.Models;

using System;
using System.ComponentModel.DataAnnotations;


public class Chef {

    [Key]
    public int ChefId {get;set;}

    [Required]
    public string FirstName {get;set;}

    [Required]
    public string LastName {get;set;}

    [Required]
    [DataType(DataType.Date)]
    [ValidationDate]
    [ValidationAge]

    public DateTime BirthDate {get;set;}

    public int Age {get{
            int age = 0;  
    age = DateTime.Now.Year - BirthDate.Year;  
    if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)  
        age = age - 1;  
  
    return age;  
                        } 
    }  

    

    public List<Dish> AllDishes { get; set; } = new List<Dish>();

    
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

public class ValidationAgeAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   
         DateTime CurrentTime = DateTime.Now;
         Console.WriteLine(value);
         TimeSpan interval = CurrentTime - (DateTime)value;
         int age=(int)interval.Days / 365;
        if (age<18)
        {
            return new ValidationResult("The chef is not over 18");
        } else {
            return ValidationResult.Success;
        }
    }






 
}

