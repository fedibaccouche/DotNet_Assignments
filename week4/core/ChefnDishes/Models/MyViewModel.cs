#pragma warning disable CS8618
namespace ChefnDishes.Models;
using System.ComponentModel.DataAnnotations;


public class MyViewModel{
    public Chef Chef {get;set;}
    public List<Chef> AllChefs {get;set;}
    public Dish Dish {get;set;}
    public List<Dish> AllDishes {get;set;}
}