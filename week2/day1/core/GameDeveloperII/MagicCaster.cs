

public class MagicCaster:Enemy{


 public MagicCaster():base("MagicCaster Fighter",80)
 {
    base.AttackList.Add(new Attack("Fireball",25 ));
    base.AttackList.Add(new Attack("Lightning Bolt",20));
    base.AttackList.Add(new Attack("Staff Strike",10));
 }

 public void Heal(Enemy target)
 {
    target.Health+=40;
    Console.WriteLine($"Health restored to {target.Health}");
 }
}