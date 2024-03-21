// See https://aka.ms/new-console-template for more information


Enemy DarthVader=new Enemy("Darth Vader");

Attack a1=new Attack("Force Choke",17);
Attack a2=new Attack("Acupressure",10);
Attack a3=new Attack("Air Cutter",6);
Attack a4=new Attack("Arm Thrust",9);

DarthVader.AttackList.Add(a1);
DarthVader.AttackList.Add(a2);
DarthVader.AttackList.Add(a3);
DarthVader.AttackList.Add(a4);

DarthVader.RandomAttack();

