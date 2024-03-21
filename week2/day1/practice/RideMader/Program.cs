

 

RideMader r1=new RideMader("Corolla","white");
RideMader r2=new RideMader("Mountain Bike",1001,"gray",false);
RideMader r3=new RideMader("Rollerblades",2,"black",false);
RideMader r4=new RideMader("Polo","Blue");

List <RideMader> l=new List<RideMader>();

l.Add(r1);
l.Add(r2);
l.Add(r3);
l.Add(r4);

foreach(RideMader r in l )
{
    r.ShowInfo();
}

r3.Travel(100);
r3.ShowInfo();
