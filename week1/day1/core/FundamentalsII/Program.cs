// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;



Console.WriteLine("Hello, World!");

int[] numbers={0,1,2,3,5,6,7,8,9};
string[] names={ "Tim", "Martin", "Nikki", "Sara"};

bool[] array=new Boolean[5];
bool first = true;
array[0]=first;
for( int i=1;i<5;i++ )
{
    first=!first;
    array[i]=first;
}

List<String> l=new List<string>();
l.Add("vanilla");
l.Add("chocolate");
l.Add("strawberry");
l.Add("Rocky Road");
l.Add("Butter Pecan");
Console.WriteLine(l.Count);
Console.WriteLine(l[2]);
l.RemoveAt(2);
Console.WriteLine(l.Count);

Random rand = new Random();
Dictionary<string,string> d = new Dictionary<string,string>();

for(int i=0 ;i<names.Length;i++)
{
    d.Add(names[i],l[rand.Next(5)]);
}

foreach(KeyValuePair<string,string> entry in d)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}
