public class Virus : ICloneable
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(string name, string species, double weight, int age)
    {
        Name = name;
        Species = species;
        Weight = weight;
        Age = age;
        Children = new List<Virus>();
    }

    public void AddChild(Virus child)
    {
        Children.Add(child);
    }

    public object Clone()
    {
        var cloned = new Virus(Name + "_Clone", Species, Weight, Age);

        foreach (var child in Children)
        {
            cloned.AddChild((Virus)child.Clone());
        }

        return cloned;
    }

    public void Info()
    {
        Console.WriteLine($"Name: {Name}, Species: {Species}, Weight: {Weight}g, Age: {Age} days");

        foreach (var child in Children)
        {
            child.Info();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var grandparentVirus = new Virus("COVID-Alpha", "Coronavirus", 0.1, 300);

            var parentVirus1 = new Virus("COVID-Beta(Alpha)", "Coronavirus", 0.08, 180);
            var parentVirus2 = new Virus("COVID-Gamma(Alpha)", "Coronavirus", 0.09, 150);

            var childVirus1 = new Virus("COVID-Delta(Beta)", "Coronavirus", 0.07, 90);
            var childVirus2 = new Virus("COVID-Omicron(Beta)", "Coronavirus", 0.06, 60);
            var childVirus3 = new Virus("COVID-Lambda(Gamma)", "Coronavirus", 0.08, 45);

            grandparentVirus.AddChild(parentVirus1);
            grandparentVirus.AddChild(parentVirus2);

            parentVirus1.AddChild(childVirus1);
            parentVirus1.AddChild(childVirus2);
            parentVirus2.AddChild(childVirus3);

            Console.WriteLine("Original family of viruses:");
            grandparentVirus.Info();

            Console.WriteLine("\nCloned family of viruses:");
            var clonedVirus = (Virus)grandparentVirus.Clone();
            clonedVirus.Info();

        }
    }

}
