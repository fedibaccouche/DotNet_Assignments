#pragma warning disable CS8618
namespace ChefnDishes.Models;
using System.ComponentModel.DataAnnotations;


public class Dish {

    [Key]
    [Required]
    public int DishId {get;set;}

    [Required]
    public string Name {get;set;}

 

    [Required]
    [ValidationTastiness]

    public int Tastiness {get;set;}

    [Required]

    [ValidationCalories]

    public int Calories {get;set;}

    public string? Description{get;set;}

    public DateTime CreatedAt {get;set;}=DateTime.Now;

    public DateTime UpdatedAt {get;set;}=DateTime.Now;
    [Required]
    public int ChefId { get; set; }

    public Chef? ChefCreator { get; set; }


}

public class ValidationTastinessAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   
         
        if ((int)value>5 || (int)value <1)
        {
            return new ValidationResult("Tastiness must be a number between 1 and 5");
        } else {
            return ValidationResult.Success;
        }
    }
}

public class ValidationCaloriesAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {   
         
        if (!( (int) value>0))
        {
            return new ValidationResult("Calories must be greater than 0");
        } else {
            return ValidationResult.Success;
        }
    }
}