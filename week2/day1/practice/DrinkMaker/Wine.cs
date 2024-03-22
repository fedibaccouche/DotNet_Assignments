
class Wine : Drink {

    string region ;
    int year ;

    public Wine(string name,string color,string r,int y):base(name,color,15,false,140)
    {
        region=r;
        year=y;
    }

         public override void ShowInfo()
    {
      base.ShowInfo();
      Console.WriteLine($"Roast region: {region}");
      Console.WriteLine($"Roast year: {year}");
      

    }
}