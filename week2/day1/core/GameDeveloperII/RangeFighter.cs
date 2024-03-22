public class RangeFighter:Enemy{
    int distance;

 public RangeFighter(int d=5):base("RangeFighter Fighter")
 {
    base.AttackList.Add(new Attack("Arrow",20));
    base.AttackList.Add(new Attack("Knive",15));
    distance=d;
    
 }

   public override Attack RandomAttack()
    {
        Random rand = new Random();
        if (AttackList.Count!=0 )
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

 public void Dash()
 {
    distance=20;
 }

public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
{
    // Write some logic here to reduce the Targets health by your Attack's DamageAmount
    if (distance >=10)
    {
    Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    Target.Health-=ChosenAttack.DamageAmount;
    }

 else {
        Console.WriteLine("Distance is less than 10");
 }

}
}

