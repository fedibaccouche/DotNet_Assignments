#pragma warning disable CS8618
namespace ProductNCategories.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class MyViewModel{
    public Product Product {get;set;}
    public List<Product> AllProducts {get;set;}
    public Categorie Categorie {get;set;}
    public List<Categorie> AllCategories {get;set;}

    public Association Association {get;set;}
}