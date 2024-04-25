#pragma warning disable CS8618
namespace ProductNCategories.Models;
using System.ComponentModel.DataAnnotations;


public class Product {

    [Key]
    public int ProductId{get;set;}

    public string Name{get;set;}

    public string Description{get;set;}

    public float Price {get;set;}

    public DateTime CreatedAt {get;set;}=DateTime.Now;

    public DateTime UpdatedAt {get;set;}=DateTime.Now;

    public List<Association> Associations{get;set;}=new List<Association>();



}