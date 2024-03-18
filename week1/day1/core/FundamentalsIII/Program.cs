// See https://aka.ms/new-console-template for more information




using System.Numerics;




static void PrintList(List<string> MyList)
{
    // Your code here
    foreach(string name in MyList)
    {
        Console.WriteLine(name);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    // Your code here
    int sum=0;
    foreach(int i in IntList)
    {
        sum+=i;
    }
    Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);


static int FindMax(List<int> IntList)
{
    // Your code here
   int max=IntList[0];
    for (int i=1;i<IntList.Count;i++)
    {
        if(max<IntList[i])
        {
            max=IntList[i];
        }
    }
   
    return max;

}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example

Console.WriteLine(FindMax(TestIntList2));


static int[] NonNegatives(int[] IntArray)
{
    // Your code here
     for (int i=0;i<IntArray.Length;i++)
     {
        if(IntArray[i]<0)
        {
            IntArray[i]=0;
        }
     }
     Console.WriteLine($"[{IntArray[0]},{IntArray[1]},{IntArray[2]},{IntArray[3]},{IntArray[4]}]");
     return IntArray;

}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    // Your code here
    foreach(KeyValuePair<string,string> entry in MyDictionary)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}


}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);


static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    // Your code here
        foreach(KeyValuePair<string,string> entry in MyDictionary)
{
    if(entry.Key==SearchTerm)
    {
        return true;
    }
    
}
return false;
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));


// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    // Your code here
    Dictionary<string,int> d = new Dictionary<string,int>();
    for(int i =0;i<Names.Count;i++)
    {
        d.Add(Names[i],Numbers[i]);
    }
    foreach(KeyValuePair<string,int> entry in d)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}
    return d;
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here


GenerateDictionary(TestStringList,TestIntList.GetRange(0,4));