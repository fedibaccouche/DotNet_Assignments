class Car : Vehicle,INeedFuel{

    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Car(string name,int number,string color,int distance,string f,int ft=10):base(name,number,color,true,distance)
    {
        FuelType=f;
        FuelTotal=ft;
    }

   public void GiveFuel(int Amount){
        FuelTotal+=Amount;
        Console.WriteLine($"Fueled the {name} with {FuelType} to {FuelTotal}.");
    }
}