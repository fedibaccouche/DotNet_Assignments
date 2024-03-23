

public abstract class Vehicle
{
    protected string name;
    protected int number ;
   protected string color;
   protected bool engine;
   protected int distance;

    public Vehicle(string n , int nu,string c,bool e,int d =0)
    {
        name=n;
        number=nu;
        color=c;
        engine=e;
        distance=d;
    }

    public Vehicle(string n,string c)
    {
        name=n;
        number=1000;
        color=c;
        engine=true;
    }


    public void ShowInfo()
    {
        Console.WriteLine($"the vehicle is {color} , its number is {number} ,engine : {engine} and it has tavalled {distance}km");
    }

    public void Travel(int d)
    {   
        distance+=d;
        Console.WriteLine($"the distance traveled is {distance}");

    }
}