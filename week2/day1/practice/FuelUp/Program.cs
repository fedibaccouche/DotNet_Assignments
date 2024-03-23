// See https://aka.ms/new-console-template for more information



Car c=new Car("Corolla",1000,"Gray",1000,"Gas");
Horse h = new Horse("Speedy",13,"Brown",1000);
Bicycle b= new Bicycle("BMX",11,"Black",false,1213);
// Vehicle v = new Vehicle();
// cannot instantiate the vehicle class

List<Vehicle>vehicles=new List<Vehicle>();
vehicles.Add(c);
vehicles.Add(h);
vehicles.Add(b);

List<INeedFuel> FuelVehicles=new List<INeedFuel> ();

foreach(Vehicle v in vehicles)
{
    if(v is INeedFuel)
    {
        FuelVehicles.Add((INeedFuel)v);
    }
}

foreach(INeedFuel i in FuelVehicles)
{
    i.GiveFuel(10);
}



