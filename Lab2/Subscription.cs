using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
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
        { };
        public override List<string> Features => new List<string>
            { "HD якість", "Мобільний доступ", "Запис програм" };
    }

    public class EducationalSubscription : Subscription
    {
        public override string Name => "Educational Subscription";
        public override decimal Price => 250;
        public override int MinPeriod => 3;
        public override List<string> Channels => new List<string>
            { "1+1", "2+2", "ICTV", "K1", "Discovery", "BBC" };
        public override List<string> Features => new List<string>
            { "Освітній контент", "Документальні фільми", "Мови оригіналу" };
    }

    public class PremiumSubscription : Subscription
    {
        public override string Name => "Premium Subscription";
        public override decimal Price => 500;
        public override int MinPeriod => 1;
        public override List<string> Channels => new List<string>
            { "1+1", "2+2", "ICTV", "K1", "Discovery", "BBC", "Netflix" };
        public override List<string> Features => new List<string>
            { "4K якість", "Без реклами", "Ексклюзивний контент", "Сімейний доступ" };
    }

    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription(string subscriptionType);

        public void ProcessSubscription(string subscriptionType)
        {
            var subscription = CreateSubscription(subscriptionType);
            Console.WriteLine($"Підписка створена через {GetType().Name}:");
            subscription.SubInfo();
        }
    }

    public class WebSite : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string subscriptionType)
        {
            Console.WriteLine("Створення підписки через веб-сайт з онлайн оплатою...");

            return subscriptionType.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                "premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки")
            };
        }
    }

    public class MobileApp : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string subscriptionType)
        {
            Console.WriteLine("Створення підписки через мобільний додаток з push-повідомленнями...");

            return subscriptionType.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                "premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки")
            };
        }
    }

    public class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string subscriptionType)
        {
            Console.WriteLine("Створення підписки через дзвінок менеджера з персональною консультацією...");

            return subscriptionType.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                "premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Невідомий тип підписки")
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ПАТЕРНІВ ПРОЕКТУВАННЯ ===\n");

            Console.WriteLine("1. ФАБРИЧНИЙ МЕТОД - Система підписок\n");

            var creators = new List<SubscriptionCreator>
            {
                new WebSite(),
                new MobileApp(),
                new ManagerCall()
            };

            var subscriptionTypes = new[] { "domestic", "educational", "premium" };

            foreach (var creator in creators)
            {
                var randomType = subscriptionTypes[new Random().Next(subscriptionTypes.Length)];
                creator.ProcessSubscription(randomType);
            }

            Console.WriteLine(new string('=', 50) + "\n");
        }
    }
}
