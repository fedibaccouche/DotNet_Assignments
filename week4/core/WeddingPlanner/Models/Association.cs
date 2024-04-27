#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
namespace WeddingPlanner.Models;


public class Association {

    [Key]

    public int Id{get;set;}

    public int UserId {get;set;}

    public int WeddingId {get;set;}


    public Wedding? Wedding {get;set;}

    public User? User {get;set;}
}