

public class Enemy{
   public string Name;
   public int Health;
    public List<Attack> AttackList =new List<Attack>();


    public Enemy(string n,int h=100)
    {
        Name=n;
        Health=h;

         
        
    }

    public virtual Attack RandomAttack()
    {
        Random rand = new Random();
        if (AttackList.Count!=0)
        {
        int i =rand.Next(AttackList.Count);
        Attack attack=AttackList[i];
        Console.WriteLine($"the random attack selected is {attack.Name}");
        return attack;
        }
        else 
        {Console.WriteLine("the attack list is empty");
        return null;
            
        }
    }

    // Inside of the Enemy class
public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
{
    // Write some logic here to reduce the Targets health by your Attack's DamageAmounts
    Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    Target.Health-=ChosenAttack.DamageAmount;
}


}