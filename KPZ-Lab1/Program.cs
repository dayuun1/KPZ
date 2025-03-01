using System;

public interface IAnimal
{
    string Name { get; set; }
    string Species { get; set; }
    Food MainFood { get; set; }
}

public class Animal : IAnimal
{
    public string Name { get; set; }
    public string Species { get; set; }
    public Food MainFood { get; set; }

    public Animal(string name, string species, Food mainFood)
    {
        Name = name;
        Species = species;
        MainFood = mainFood;
    }
}

public class Carnivore : Animal
{
    private static readonly Food DefaultFood = new Food("Meat", "Meat factory");

    public Carnivore(string name, string species) : base(name, species, DefaultFood) { }
}

public class Herbivore : Animal
{
    private static readonly Food DefaultFood = new Food("Vegetable", "Vegetable base");

    public Herbivore(string name, string species) : base(name, species, DefaultFood) { }
}

public class Food
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Food(string name, string type)
    {
        Name = name;
        Type = type;
    }
}

public class Enclosure
{
    public string Type { get; set; }
    public int Capacity { get; set; }
    private readonly List<IAnimal> _animals = new();

    public Enclosure(string type, int capacity)
    {
        Type = type;
        Capacity = capacity;
    }

    public bool AddAnimal(IAnimal animal)
    {
        if (_animals.Count >= Capacity)
        {
            Console.WriteLine("Enclosure is full.");
            return false;
        }

        if (_animals.Any(a => (a is Carnivore && animal is Herbivore) || (a is Herbivore && animal is Carnivore)))
        {
            Console.WriteLine($"{animal.Name} cannot be in the same enclosure with another species.");
            return false;
        }

        _animals.Add(animal);
        return true;
    }

    public void EnclosureAnimals()
    {
        _animals.ForEach(a => Console.WriteLine($"{a.Name} ({a.Species}). Main food: {a.MainFood.Name}"));
    }
}

public abstract class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    protected Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
}

public class Zookeeper : Employee
{
    public List<IAnimal> _fedAnimals { get; set; } = new();

    public Zookeeper(string name, decimal salary) : base(name, salary) { }

    public void ZookeeperAnimals()
    {
        Console.WriteLine($"{Name} feeds:");
        foreach (var animal in _fedAnimals)
        {
            Console.WriteLine($"{animal.Name}");
        }
        Console.WriteLine($"-------------");
    }
}

public class Veterinarian : Employee
{
    public string Specialization { get; set; }

    public Veterinarian(string name, decimal salary, string specialization) : base(name, salary)
    {
        Specialization = specialization;
    }
}

public class Inventory
{
    private readonly List<Enclosure> _enclosures;
    private readonly List<Employee> _employees;

    public Inventory(List<Enclosure> enclosures, List<Employee> employees)
    {
        _enclosures = enclosures;
        _employees = employees;
    }

    public void ShowInfo()
    {
        Console.WriteLine("Animals:");
        _enclosures.ForEach(e => e.EnclosureAnimals());
        Console.WriteLine("\nEmployees:");
        _employees.ForEach(e => Console.WriteLine($"{e.Name} - Salary: {e.Salary}"));
    }
}

public class Program
{
    public static void Main()
    {
        var lion = new Carnivore("Alex", "Lion");
        var giraffe = new Herbivore("Melmat", "Giraffe");
        var lion2 = new Carnivore("Zuba", "Lion");
        var tiger = new Carnivore("Vitaliy", "Tiger");

        var enclosure = new Enclosure("Carnivore", 2);
        if (enclosure.AddAnimal(lion))
            Console.WriteLine("Added a lion");
        if (enclosure.AddAnimal(giraffe)) 
            Console.WriteLine("Added a giraffe");
        if (enclosure.AddAnimal(tiger))
            Console.WriteLine("Added a tiger");
        if (enclosure.AddAnimal(lion2))
            Console.WriteLine("Added a lion2");

        var zookeeper = new Zookeeper("Andriy", 10000);
        zookeeper._fedAnimals.Add(lion);
        zookeeper.ZookeeperAnimals();
        var veterinarian = new Veterinarian("Vadim", 20000, "Carnivore");

        var inventory = new Inventory(new List<Enclosure> { enclosure }, new List<Employee> { zookeeper, veterinarian });
        inventory.ShowInfo();
    }
}
