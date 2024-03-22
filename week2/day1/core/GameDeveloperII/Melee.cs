using System.Reflection;

public class Melee:Enemy{


 public Melee():base("Melee Fighter",120)
 {
    base.AttackList.Add(new Attack("Punch",20));
    base.AttackList.Add(new Attack("Kick",15));
    base.AttackList.Add(new Attack("Punch",25));
 }

 public void RageAttack(Enemy target)
 {
    Attack a =base.RandomAttack();
    target.Health-=a.DamageAmount-10;
 }
}