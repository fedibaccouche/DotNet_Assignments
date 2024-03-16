// See https://aka.ms/new-console-template for more information



for (int i=1;i<=255;i++)
{
    Console.WriteLine(i);
}
Random rand = new Random();
int sum=0;
for(int i = 1; i <= 5; i++)
{
    int x=rand.Next(2,21);
    Console.WriteLine(x);
    sum+=x;
}

Console.WriteLine(sum);

for(int i = 1; i <= 100; i++)
{
    if(!(i%5==0 && i%3==0))
    {
        if (i%5==0){
            
            Console.WriteLine("fizz");
        }
                if (i%3==0){
            Console.WriteLine("buzz");
        }
    }
    else {
        Console.WriteLine("Fizzbuzz");
    }
}