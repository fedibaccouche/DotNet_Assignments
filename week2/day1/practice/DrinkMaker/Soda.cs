class Soda : Drink{

    bool isdiet;

    public Soda(string name,string color,int calories,bool diet):base(name,color,5,true,calories)
    {
        isdiet=diet;
    }
    
    public override void ShowInfo()
    {
      base.ShowInfo();
      Console.WriteLine($"isdiet: {isdiet}");

    }

}