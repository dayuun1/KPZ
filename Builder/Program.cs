
public class Character
{
public string Name { get; set; }
public int Height { get; set; }
public string Build { get; set; }
public string HairColor { get; set; }
public string EyeColor { get; set; }
public string Clothing { get; set; }
public List<string> Inventory { get; set; }
public List<string> GoodDeeds { get; set; }
public List<string> EvilDeeds { get; set; }
public string Alignment { get; set; }

public Character()
{
    Inventory = new List<string>();
    GoodDeeds = new List<string>();
    EvilDeeds = new List<string>();
}

public void Info()
{
    Console.WriteLine($"--===-- {Name} --===--");
    Console.WriteLine($"Height: {Height} см");
    Console.WriteLine($"Build: {Build}");
    Console.WriteLine($"Hair Color: {HairColor}");
    Console.WriteLine($"Eye Color: {EyeColor}");
    Console.WriteLine($"Clothing: {Clothing}");
    Console.WriteLine($"Alignment: {Alignment}");

    if (Inventory.Any())
        Console.WriteLine($"Inventory: {string.Join(", ", Inventory)}");

    if (GoodDeeds.Any())
        Console.WriteLine($"Good Deeds: {string.Join(", ", GoodDeeds)}");

    if (EvilDeeds.Any())
        Console.WriteLine($"Evil Deeds: {string.Join(", ", EvilDeeds)}");

    Console.WriteLine();
}
    }

    public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string color);
    ICharacterBuilder SetEyeColor(string color);
    ICharacterBuilder SetClothing(string clothing);
    ICharacterBuilder AddInventoryItem(string item);
    Character Build();
}

public class HeroBuilder : ICharacterBuilder
{
    private Character _character;

    public HeroBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _character = new Character { Alignment = "Good" };
    }

    public ICharacterBuilder SetName(string name)
    {
        _character.Name = name;
        return this;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string color)
    {
        _character.HairColor = color;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string color)
    {
        _character.EyeColor = color;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder AddInventoryItem(string item)
    {
        _character.Inventory.Add(item);
        return this;
    }

    public HeroBuilder AddGoodDeed(string deed)
    {
        _character.GoodDeeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        var result = _character;
        Reset();
        return result;
    }
}

public class EnemyBuilder : ICharacterBuilder
{
    private Character _character;

    public EnemyBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _character = new Character { Alignment = "Bad" };
    }

    public ICharacterBuilder SetName(string name)
    {
        _character.Name = name;
        return this;
    }

    public ICharacterBuilder SetHeight(int height)
    {
        _character.Height = height;
        return this;
    }

    public ICharacterBuilder SetBuild(string build)
    {
        _character.Build = build;
        return this;
    }

    public ICharacterBuilder SetHairColor(string color)
    {
        _character.HairColor = color;
        return this;
    }

    public ICharacterBuilder SetEyeColor(string color)
    {
        _character.EyeColor = color;
        return this;
    }

    public ICharacterBuilder SetClothing(string clothing)
    {
        _character.Clothing = clothing;
        return this;
    }

    public ICharacterBuilder AddInventoryItem(string item)
    {
        _character.Inventory.Add(item);
        return this;
    }

    public EnemyBuilder AddEvilDeed(string deed)
    {
        _character.EvilDeeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        var result = _character;
        Reset();
        return result;
    }
}

public class CharacterDirector
{
    public Character CreateHero(HeroBuilder builder)
    {
        return ((HeroBuilder)builder.SetName("Svitlana Bronislavivna")
                                   .SetHeight(145)
                                   .SetBuild("Athletic")
                                   .SetHairColor("Black")
                                   .SetEyeColor("Brown ")
                                   .SetClothing("Naked")
                                   .AddInventoryItem("Arbalest")
                                   .AddInventoryItem("Shield")
                                   .AddInventoryItem("Sandwich"))
                     .AddGoodDeed("Saved the village from dragons")
                     .AddGoodDeed("Helped children")
                     .Build();
    }

    public Character CreateEnemy(EnemyBuilder builder)
    {
        return ((EnemyBuilder)builder.SetName("Orc")
                                    .SetHeight(345)
                                    .SetBuild("Bent")
                                    .SetHairColor("Brown")
                                    .SetEyeColor("Red")
                                    .SetClothing("Naked")
                                    .AddInventoryItem("Stick"))
                     .AddEvilDeed("Broke into the Hogwarts toilet")
                     .Build();
    }

    class Program
    {
        static void Main(string[] args)
        {

            var director = new CharacterDirector();
            var heroBuilder = new HeroBuilder();
            var enemyBuilder = new EnemyBuilder();

            var hero = director.CreateHero(heroBuilder);
            var enemy = director.CreateEnemy(enemyBuilder);

            Console.WriteLine("Hero:");
            hero.Info();

            Console.WriteLine("Enemy:");
            enemy.Info();

        }
    }
}