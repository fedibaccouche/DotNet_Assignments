

class Enemy{
    string Name;
    int Health=100 ;
    public List<Attack> AttackList =new List<Attack>();


    public Enemy(string n)
    {
        Name=n;

         
        
    }

    public void RandomAttack()
    {
        Random rand = new Random();
        if (AttackList.Count!=0)
        {
        int i =rand.Next(AttackList.Count);
        string attack=AttackList[i].Name;
        Console.WriteLine($"the random attack selected is {attack}");
        }
        else Console.WriteLine("the attack list is empty");
    }
}