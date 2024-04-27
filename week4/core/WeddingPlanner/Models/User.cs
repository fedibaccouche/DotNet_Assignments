#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
namespace WeddingPlanner.Models;
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [Display(Name ="First Name")]
    [MinLength(2,ErrorMessage = "First Name must be at least 2 characters")] 
    public string FirstName { get; set; } 

    [Display(Name ="Last Name")]
    [Required]
    [MinLength(2,ErrorMessage = "LastName must be at least 2 characters")] 
    public string LastName { get; set; } 
    [Display(Name ="Email Address")]
    [Required]
    [DataType(DataType.EmailAddress)]
    [UniqueEmail]
    public string Email { get; set; } 

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; }

        
    // This does not need to be moved to the bottom
    // But it helps make it clear what is being mapped and what is not
    [NotMapped]
    // There is also a built-in attribute for comparing two fields we can use!
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }          
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Wedding> MyWeddings { get; set; } = new List<Wedding>();

    public List<Association> Associations{get;set;}=new List<Association>();
    
}



public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Email is required!");
        }
    
    	// This will connect us to our database since we are not in our Controller
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        }
       
        // if(!(Email.IsValidEmail( value.ToString())))
        // {
        //     return new ValidationResult("Email format is wrong");
        // }
         else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}
