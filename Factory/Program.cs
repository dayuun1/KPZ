public interface ILaptop
{
    void DisplayDevice();
}

public interface ISmartphone
{
    void DisplayDevice();
}

public interface INetbook
{
    void DisplayDevice();
}

public interface IEBook
{
    void DisplayDevice();
}

public class IProneeLaptop : ILaptop
{
    public void DisplayDevice() => Console.WriteLine("MacBook");
}

public class IProneeSmartphone : ISmartphone
{
    public void DisplayDevice() => Console.WriteLine("IPronee 16");
}

public class IProneeNetbook : INetbook
{
    public void DisplayDevice() => Console.WriteLine("MacBook Air");
}

public class IProneeEBook : IEBook
{
    public void DisplayDevice() => Console.WriteLine("IPronee iPad");
}

public class KiaomiLaptop : ILaptop
{
    public void DisplayDevice() => Console.WriteLine("Kiaomi Laptop");
}

public class KiaomiSmartphone : ISmartphone
{
    public void DisplayDevice() => Console.WriteLine("Kiaomi 4");
}

public class KiaomiNetbook : INetbook
{
    public void DisplayDevice() => Console.WriteLine("Kiaomi Notebook");
}

public class KiaomiEBook : IEBook
{
    public void DisplayDevice() => Console.WriteLine("Kiaomi Pad");
}

public class BalaxyLaptop : ILaptop
{
    public void DisplayDevice() => Console.WriteLine("Balaxy Laptop");
}

public class BalaxySmartphone : ISmartphone
{
    public void DisplayDevice() => Console.WriteLine("Balaxy S24");
}

public class BalaxyNetbook : INetbook
{
    public void DisplayDevice() => Console.WriteLine("Balaxy Book");
}

public class BalaxyEBook : IEBook
{
    public void DisplayDevice() => Console.WriteLine("Balaxy EBook");
}

public interface IDeviceFactory
{
    ILaptop CreateLaptop();
    ISmartphone CreateSmartphone();
    INetbook CreateNetbook();
    IEBook CreateEBook();
}
public class IProneeFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new IProneeLaptop();
    public ISmartphone CreateSmartphone() => new IProneeSmartphone();
    public INetbook CreateNetbook() => new IProneeNetbook();
    public IEBook CreateEBook() => new IProneeEBook();
}

public class KiaomiFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new KiaomiLaptop();
    public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
    public INetbook CreateNetbook() => new KiaomiNetbook();
    public IEBook CreateEBook() => new KiaomiEBook();
}

public class BalaxyFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
    public INetbook CreateNetbook() => new BalaxyNetbook();
    public IEBook CreateEBook() => new BalaxyEBook();
}

class Program
{
    static void Main(string[] args)
    {

        var factories = new List<IDeviceFactory>
            {
                new IProneeFactory(),
                new KiaomiFactory(),
                new BalaxyFactory()
            };

        foreach (var factory in factories)
        {
            Console.WriteLine($"Фабрика {factory.GetType().Name}:");
            factory.CreateLaptop().DisplayDevice();
            factory.CreateSmartphone().DisplayDevice();
            factory.CreateNetbook().DisplayDevice();
            factory.CreateEBook().DisplayDevice();
            Console.WriteLine();
        }
    }
}