#pragma warning disable CS8618
namespace WeddingPlanner.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class MyViewModel{
    public User User {get;set;}
    public List<Wedding> AllWeddings{get;set;}
    public Wedding Wedding {get;set;}
    public List<User> AllUsers {get;set;}

    public Association Association {get;set;}
}