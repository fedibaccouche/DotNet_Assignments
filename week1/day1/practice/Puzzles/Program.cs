// See https://aka.ms/new-console-template for more information







static void CoinFlip(){
    Random rand = new Random();
    int i=rand.Next(2);
    if (i==0)
    {
        Console.WriteLine("Face");
    }
    else {
        Console.WriteLine("Tail");
    }
}

CoinFlip();

static int DiceRoll(){
    Random rand = new Random();
    int i=rand.Next(7);
    return i;
}

Console.WriteLine(DiceRoll());

static void StatRoll(){
   
    List<int> result=new List<int>();
    for(int i=0;i<4;i++)
    {
        result.Add(DiceRoll());
    }
    foreach(int i in result)
    {
        Console.WriteLine(i);
    }

}

StatRoll();

static void RollUntil(int number){
   
    if(number>1 && number<=6)
    {
        int count=0;
        while(number!=DiceRoll())
        {
            count++;
        }
    Console.WriteLine($"Rolled a {number} after {count} tries");
    }
    

}


RollUntil(6);

