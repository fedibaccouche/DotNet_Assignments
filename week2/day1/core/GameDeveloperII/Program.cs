// See https://aka.ms/new-console-template for more information


MagicCaster mc=new MagicCaster();
RangeFighter rf=new RangeFighter();
Melee m=new Melee();

m.PerformAttack(rf,m.AttackList[0]);
m.RageAttack(mc);
rf.PerformAttack(m,rf.AttackList[0]);
rf.Dash();
rf.PerformAttack(m,rf.AttackList[0]);
mc.PerformAttack(m,mc.AttackList[0]);
mc.Heal(rf);
mc.Heal(mc);