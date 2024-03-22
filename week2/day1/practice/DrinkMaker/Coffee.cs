class Coffee : Drink{


 string roastValue;
 string typeBeans;


 public Coffee(string color,int calories,string rv,string tb):base("coffee",color,50,false,calories)
 {
    roastValue=rv;
    typeBeans=tb;
 }

     public override void ShowInfo()
    {
      base.ShowInfo();
      Console.WriteLine($"Roast Value: {roastValue}");
      Console.WriteLine($"Roast typeBeans: {typeBeans}");
      

    }
}