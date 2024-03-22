
using System.Collections.Generic;

Soda coke=new Soda("Coca Cola","black",139,false);
Coffee coffee=new Coffee("Capuccino",150,"dark roast","arabian beans");
Wine wine=new Wine("Haut Mornag","rosé","Tunis",2015);
List<Drink> AllBeverages=new List<Drink>();
AllBeverages.Add(coke);
AllBeverages.Add(coffee);
AllBeverages.Add(wine);

foreach(Drink d in AllBeverages){
    d.ShowInfo();
}
