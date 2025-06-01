public abstract class Subscription
{
    public abstract string Name { get; }
    public abstract decimal Price { get; }
    public abstract int MinPeriod { get; }
    public abstract List<string> Channels { get; }
    public abstract List<string> Features { get; }

    public virtual void SubInfo()
    {
        Console.WriteLine($"Subscription: {Name}");
        Console.WriteLine($"Mounth fee: ${Price}");
        Console.WriteLine($"Min Period: {MinPeriod}");
        Console.WriteLine($"Channels: {string.Join(", ", Channels)}");
        Console.WriteLine($"Features: {string.Join(", ", Features)}");
        Console.WriteLine();
    }
}

public class DomesticSubscription : Subscription
{
    public override string Name => "Domestic Subscription";
    public override decimal Price => 100;
    public override int MinPeriod => 1;
    public override List<string> Channels => new List<string>
    { "1+1", "2+2", "ICTV", "K1" };
    public override List<string> Features => new List<string>
            { "HD quality", "Program recording" };
}

public class EducationalSubscription : Subscription
{
    public override string Name => "Educational Subscription";
    public override decimal Price => 250;
    public override int MinPeriod => 3;
    public override List<string> Channels => new List<string>
            { "1+1", "2+2", "ICTV", "K1", "Discovery", "BBC" };
    public override List<string> Features => new List<string>
            { "HD quality", "Program recording", "Documentary films"};
}

public class PremiumSubscription : Subscription
{
    public override string Name => "Premium Subscription";
    public override decimal Price => 500;
    public override int MinPeriod => 1;
    public override List<string> Channels => new List<string>
            { "1+1", "2+2", "ICTV", "K1", "Discovery", "BBC", "Netflix" };
    public override List<string> Features => new List<string>
            { "HD quality", "Program recording", "Documentary films", "4k quality" };
}

public abstract class SubscriptionCreator
{
    public abstract Subscription CreateSubscription(string subscriptionType);

    public void ProcessSubscription(string subscriptionType)
    {
        var subscription = CreateSubscription(subscriptionType);
        subscription.SubInfo();
    }
}

public class WebSite : SubscriptionCreator
{
    public override Subscription CreateSubscription(string subscriptionType)
    {
        Console.WriteLine("Creating a subscription through a website");

        return subscriptionType.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Unknowm subscription")
        };
    }
}

public class MobileApp : SubscriptionCreator
{
    public override Subscription CreateSubscription(string subscriptionType)
    {
        Console.WriteLine("Creating a subscription via a mobile app");

        return subscriptionType.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Unknowm subscription")
        };
    }
}

public class ManagerCall : SubscriptionCreator
{
    public override Subscription CreateSubscription(string subscriptionType)
    {
        Console.WriteLine("Creating a subscription via a call manager");

        return subscriptionType.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Unknowm subscription")
        };
    }
}

class Program
{
    static void Main(string[] args)
    {

        var creators = new List<SubscriptionCreator>
            {
                new WebSite(),
                new MobileApp(),
                new ManagerCall()
            };

        var subscriptionTypes = new[] { "domestic", "educational", "premium" };

        foreach (var creator in creators)
        {
            creator.ProcessSubscription("domestic");
            creator.ProcessSubscription("educational");
            creator.ProcessSubscription("premium");
        }

    }
}

