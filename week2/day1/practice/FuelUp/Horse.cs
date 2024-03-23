public class Horse : Vehicle,INeedFuel{

    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    
    public Horse(string name,int number,string color,int distance,int ft=10):base(name,number,color,false,distance)
    {
        FuelType="Hay";
        FuelTotal=ft;
        
    }
    
    public void GiveFuel(int Amount)
    {
        FuelTotal+=Amount;
        Console.WriteLine($"Fed {name} some {FuelType}.");
    }
}