

class RideMader
{
    string name;
    int number ;
    string color;
    bool engine;
    int distance=0 ;

    public RideMader(string n , int nu,string c,bool e )
    {
        name=n;
        number=nu;
        color=c;
        engine=e;
    }

    public RideMader(string n,string c)
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