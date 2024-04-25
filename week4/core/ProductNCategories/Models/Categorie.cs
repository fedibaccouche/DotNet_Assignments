#pragma warning disable CS8618
namespace ProductNCategories.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Categorie {

    [Key]
    public int CategorieId{get;set;}

    public string Name{get;set;}


    public DateTime CreatedAt {get;set;}=DateTime.Now;

    public DateTime UpdatedAt {get;set;}=DateTime.Now;

    public List<Association> Associations{get;set;}=new List<Association>();


}