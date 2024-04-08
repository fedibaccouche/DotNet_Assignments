// See https://aka.ms/new-console-template for more information













List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

Eruption  first_chilie= eruptions.First((c =>c.Location=="Chile"));
Console.WriteLine(first_chilie.ToString());

Eruption  hawaii= eruptions.FirstOrDefault((c =>c.Location=="Hawaiian Is"));

if(hawaii==null)
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}
else 
{
    Console.WriteLine(hawaii.ToString());
}

Eruption  greenland= eruptions.FirstOrDefault((c =>c.Location=="Greenland"));
if(greenland==null)
{
    Console.WriteLine("No Greenland Is Eruption found.");
}
else 
{
    Console.WriteLine(hawaii.ToString());
}

Eruption nz=eruptions.Where(l=>l.Location=="New Zealand").First(y=>y.Year>1900);

Console.WriteLine(nz.ToString());


IEnumerable<Eruption> volcanos_2000=eruptions.Where(e=>e.ElevationInMeters>2000);

PrintEach(volcanos_2000);

IEnumerable<Eruption> volcanos_L=eruptions.Where(n=>n.Volcano.StartsWith("L"));
PrintEach(volcanos_2000);
Console.WriteLine(volcanos_L.Count());

int highest=eruptions.Max(c=>c.ElevationInMeters);

Console.WriteLine(highest);

Eruption name_highest = eruptions.FirstOrDefault(c=>c.ElevationInMeters==highest);
// Console.WriteLine(name_highest);
Console.WriteLine(name_highest.Volcano);




PrintEach(eruptions.OrderBy(c=>c.Volcano));

Console.WriteLine(eruptions.Sum(c=>c.ElevationInMeters));

Console.WriteLine(eruptions.Any(c=>c.ElevationInMeters==2000));

PrintEach(eruptions.Where(c=>c.Type=="Stratovolcano").Take(3));
Console.WriteLine("*******************************");
PrintEach(eruptions.Where(c=>c.Year<1000).OrderBy(c=>c.Volcano));

Console.WriteLine("****************** Only names of volcanos before the year 1000 CE*********************");

foreach(string v_name in eruptions.Where(c=>c.Year<1000).OrderBy(c=>c.Volcano).Select(c=>c.Volcano))
{
    Console.WriteLine(v_name);
}
