public interface ICommandCentre
{
    void RegisterAircraft(Aircraft aircraft);
    void RegisterRunway(Runway runway);
    void RequestLanding(Aircraft aircraft);
    void RequestTakeOff(Aircraft aircraft);
    void NotifyRunwayAvailable(Runway runway);
}

public class Aircraft
{
    private readonly ICommandCentre _commandCentre;
    public string Name { get; }

    public Aircraft(string name, ICommandCentre commandCentre)
    {
        Name = name;
        _commandCentre = commandCentre;
        _commandCentre.RegisterAircraft(this);
    }

    public void RequestLanding()
    {
        Console.WriteLine($"{Name} запитує дозвіл на посадку.");
        _commandCentre.RequestLanding(this);
    }

    public void Land()
    {
        Console.WriteLine($"{Name} приземляється.");
    }
    public void RequestTakeOff()
    {
        Console.WriteLine($"{Name} запитує дозвіл на взліт.");
        _commandCentre.RequestTakeOff(this);
    }

    public void TakeOff()
    {
        Console.WriteLine($"{Name} Взлітає.");
    }
}

public class Runway
{
    private readonly ICommandCentre _commandCentre;
    public string Name { get; }
    public bool IsAvailable { get; private set; } = true;

    public Runway(string name, ICommandCentre commandCentre)
    {
        Name = name;
        _commandCentre = commandCentre;
        _commandCentre.RegisterRunway(this);
    }

    public void Occupy()
    {
        IsAvailable = false;
        Console.WriteLine($"Смуга {Name} зайнята.");
    }

    public void Release()
    {
        IsAvailable = true;
        Console.WriteLine($"Смуга {Name} звільнена.");
        _commandCentre.NotifyRunwayAvailable(this);
    }
}

public class CommandCentre : ICommandCentre
{
    private readonly List<Aircraft> _aircrafts = new();
    private readonly List<Runway> _runways = new();
    private readonly Queue<Aircraft> _landingQueue = new();
    private readonly Queue<Aircraft> _takeOffQueue = new();

    public void RegisterAircraft(Aircraft aircraft)
    {
        _aircrafts.Add(aircraft);
    }

    public void RegisterRunway(Runway runway)
    {
        _runways.Add(runway);
    }

    public void RequestLanding(Aircraft aircraft)
    {
        var availableRunway = _runways.FirstOrDefault(r => r.IsAvailable);
        if (availableRunway != null)
        {
            availableRunway.Occupy();
            aircraft.Land();
            Task.Delay(1000).ContinueWith(_ => availableRunway.Release());
        }
        else
        {
            Console.WriteLine($"{aircraft.Name} додано до черги на посадку.");
            _landingQueue.Enqueue(aircraft);
        }
    }

    public void RequestTakeOff(Aircraft aircraft)
    {
        var availableRunway = _runways.FirstOrDefault(r => r.IsAvailable);
        if (availableRunway != null)
        {
            availableRunway.Occupy();
            aircraft.TakeOff();
            Task.Delay(2000).ContinueWith(_ => availableRunway.Release());
        }
        else
        {
            Console.WriteLine($"{aircraft.Name} додано до черги на взліт.");
            _takeOffQueue.Enqueue(aircraft);
        }
    }

    public void NotifyRunwayAvailable(Runway runway)
    {
        if (_landingQueue.Any())
        {
            var nextAircraft = _landingQueue.Dequeue();
            Console.WriteLine($"{nextAircraft.Name} отримує дозвіл на посадку на смугу {runway.Name}.");
            runway.Occupy();
            nextAircraft.Land();
            Task.Delay(2000).ContinueWith(_ =>  runway.Release());
        }
        else if (_takeOffQueue.Any())
        {
            var nextAircraft = _takeOffQueue.Dequeue();
            Console.WriteLine($"{nextAircraft.Name} отримує дозвіл на взліт зі смуги {runway.Name}.");
            runway.Occupy();
            nextAircraft.TakeOff();
            Task.Delay(2000).ContinueWith(_ =>  runway.Release());
        }
    }
}

public class Program
{
    public static void Main()
    {
        ICommandCentre commandCentre = new CommandCentre();

        var runway1 = new Runway("Смуга 1", commandCentre);
        var runway2 = new Runway("Смуга 2", commandCentre);

        var aircraft1 = new Aircraft("Літак 1", commandCentre);
        var aircraft2 = new Aircraft("Літак 2", commandCentre);
        var aircraft3 = new Aircraft("Літак 3", commandCentre);
        var aircraft4 = new Aircraft("Літак 4", commandCentre);
        var aircraft5 = new Aircraft("Літак 5", commandCentre);

        aircraft1.RequestLanding();
        aircraft2.RequestTakeOff();
        aircraft3.RequestLanding();
        aircraft4.RequestLanding();
        aircraft5.RequestTakeOff();

        Thread.Sleep(10000);
    }
}
