 interface INeedFuel
{
    string FuelType {get;set;}
    int FuelTotal {get;set;}
   public void GiveFuel(int Amount);
}

