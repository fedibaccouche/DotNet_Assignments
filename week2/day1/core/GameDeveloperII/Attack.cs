

public class Attack {
    public string Name;
    public int DamageAmount;
    

    public Attack(string n ,int d)
    {
        Name=n;
        if ( d<=25 && d>=5)
        {
        DamageAmount=d;
        }
        else {
        DamageAmount=0;
        }
    }
}