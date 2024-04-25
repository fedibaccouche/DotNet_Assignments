#pragma warning disable CS8618
namespace ProductNCategories.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Association{

public int AssociationId{get;set;}

public int ProductId{get;set;}

public int CategorieId {get;set;}

public Categorie? Categorie {get;set;} 
public Product? Product {get;set;} 


}