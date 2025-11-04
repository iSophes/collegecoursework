public class Player()
{
    private int LifePoints = 3;
    public int SetLifePoints(int NewLifePoints)
    {
        LifePoints = NewLifePoints;
        
        return NewLifePoints;
    }
    public int GetLifePoints()
    {
        return LifePoints;
    }
}
public  class Monster(string Name, int MaxHealth, string Dialogue)
{
    protected string Name = Name;
    protected int Health = MaxHealth;
    protected int MaxHealth = MaxHealth;
    protected int Money = 0;
    protected string Dialogue = Dialogue;
    public int TakeDamage(int Damage)
    {
        Health -= Damage;
        if (Health < 0)
        {
            Health = 0;
        }
        Console.WriteLine($"{Name} now has {Health} health after taking {Damage} damage.");
        if (Health == 0)
        {
            Kill();
        }
        return Health;
    }
    public void SayDialogue()
    {
        Console.WriteLine($"{Name} says: '{Dialogue}'. They have currently got ${Money}");
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    public void Kill()
    {
        Console.WriteLine($"{Name} died!");
        Dispose();
    }
    public int AddMoney(int NewMoney)
    {
        Money += NewMoney;
        return Money;
    }
    public int GetMoney()
    {
        return Money;
    }
}
public class Friend(string Name, int MaxHealth, string Dialogue, string HighFiveDialogue, string Gift) : Monster(Name, MaxHealth, Dialogue)
{
    private string HighFiveDialogue = HighFiveDialogue;
    private string Gift = Gift;
    public void HighFive(Player player)
    {
        Console.WriteLine(HighFiveDialogue);
        Console.WriteLine($"{this.Name} befriends you and gives you {Gift}!");
    }
    public bool Fight(Player player)
    {
        return false;
    }
}
public class Enemy(string Name, int MaxHealth, string Dialogue, string Weakness, string FightDialogue) : Monster(Name, MaxHealth, Dialogue)
{
    private string Weakness = Weakness;
    private string FightDialogue = FightDialogue;
    public void HighFive(Player player)
    {
        Console.WriteLine("That monster was hostile. It hurt you.");
        player.SetLifePoints(player.GetLifePoints() - 1);
    }
    
    public bool Fight(Player player)
    {
        Console.WriteLine(FightDialogue);
        Console.WriteLine("Choose a weapon against this enemy: ");
        string Weapon = Console.ReadLine() ?? "";
        if (Weapon == Weakness)
        {
            Console.WriteLine("You beat the enemy!");
            return true;
        }
        Console.WriteLine("You lost the fight and took damage!");
        player.SetLifePoints(player.GetLifePoints() - 1);
        return true;
    }
    
}
class Game()
{
    public static void Main(String[] args)
    {
        Random random = new Random();
        Player player = new Player();
        
        while (true)
        {
            dynamic monster = null;
            if (random.Next(1,3) == 1)
            {
                monster = new Friend("Emma", 100, "Hi", "sure", "height buff");
            } else {
                monster = new Enemy("Chris", 200, "The terminator", "Photos", "I can be your fairy godmother or I can kill you"); 
            }
            Console.WriteLine("A monster has appeared!");
            monster.SayDialogue();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. High Five");
            Console.WriteLine("2. Fight");
            string Input = Console.ReadLine() ?? "";
            if (Input == "1")
            {
                monster.HighFive(player);  
            }
            if (Input == "2")
            {
                bool foughtMonster = monster.Fight(player);
                if (foughtMonster == false)
                {
                    Console.WriteLine("You scared the monster off. You're horrible!");
                }   
            }
        }
    }
}