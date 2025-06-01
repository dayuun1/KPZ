using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;

namespace DesignPatterns
{
    // ===== ЗАВДАННЯ 1: ФАБРИЧНИЙ МЕТОД =====

    // Абстрактний клас підписки
    public abstract class Subscription
    {
        public abstract decimal MonthlyFee { get; }
        public abstract int MinimumPeriodMonths { get; }
        public abstract List<string> Channels { get; }
        public abstract List<string> Features { get; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Тип підписки: {GetType().Name}");
            Console.WriteLine($"Щомісячна плата: ${MonthlyFee}");
            Console.WriteLine($"Мінімальний період: {MinimumPeriodMonths} міс.");
            Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
            Console.WriteLine($"Можливості: {string.Join(", ", Features)}");
            Console.WriteLine();
        }
    }

    // Конкретні підписки
    public class DomesticSubscription : Subscription
    {
        public override decimal MonthlyFee => 9.99m;
        public override int MinimumPeriodMonths => 1;
        public override List<string> Channels => new List<string>
            { "1+1", "Інтер", "СТБ", "ICTV", "Новий канал" };
        public override List<string> Features => new List<string>
            { "HD якість", "Мобільний доступ", "Запис програм" };
    }

    public class EducationalSubscription : Subscription
    {
        public override decimal MonthlyFee => 4.99m;
        public override int MinimumPeriodMonths => 3;
        public override List<string> Channels => new List<string>
            { "Discovery", "National Geographic", "BBC", "History Channel" };
        public override List<string> Features => new List<string>
            { "Освітній контент", "Документальні фільми", "Мови оригіналу" };
    }

    public class PremiumSubscription : Subscription
    {
        public override decimal MonthlyFee => 19.99m;
        public override int MinimumPeriodMonths => 1;
        public override List<string> Channels => new List<string>
            { "HBO", "Netflix Premium", "Disney+", "Amazon Prime", "Apple TV+" };
        public override List<string> Features => new List<string>
            { "4K якість", "Без реклами", "Ексклюзивний контент", "Сімейний доступ" };
    }

    // Абстрактна фабрика для створення підписок
    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription(string subscriptionType);

        public void ProcessSubscription(string subscriptionType)
        {
            var subscription = CreateSubscription(subscriptionType);
            Console.WriteLine($"Підписка створена через {GetType().Name}:");
            subscription.DisplayInfo();
        }
    }

    // Конкретні фабрики
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

    // ===== ЗАВДАННЯ 2: АБСТРАКТНА ФАБРИКА =====

    // Абстрактні продукти
    public interface ILaptop
    {
        void DisplaySpecs();
    }

    public interface ISmartphone
    {
        void DisplaySpecs();
    }

    public interface INetbook
    {
        void DisplaySpecs();
    }

    public interface IEBook
    {
        void DisplaySpecs();
    }

    // Продукти бренду IProne
    public class IProneeLaptop : ILaptop
    {
        public void DisplaySpecs() => Console.WriteLine("IPronee MacBook Pro - 16GB RAM, M2 chip, Retina Display");
    }

    public class IProneeSmartphone : ISmartphone
    {
        public void DisplaySpecs() => Console.WriteLine("IPronee Phone 15 - A17 chip, 128GB, Triple camera");
    }

    public class IProneeNetbook : INetbook
    {
        public void DisplaySpecs() => Console.WriteLine("IPronee MacBook Air - 8GB RAM, M2 chip, Ultra-portable");
    }

    public class IProneeEBook : IEBook
    {
        public void DisplaySpecs() => Console.WriteLine("IPronee iPad - 10.9 inch, Apple Pencil support");
    }

    // Продукти бренду Kiaomi
    public class KiaomiLaptop : ILaptop
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Mi Laptop - 16GB RAM, Intel i7, Gaming ready");
    }

    public class KiaomiSmartphone : ISmartphone
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Mi 13 - Snapdragon 8 Gen 2, 256GB, 50MP camera");
    }

    public class KiaomiNetbook : INetbook
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Mi Notebook - 8GB RAM, Ryzen 5, Lightweight");
    }

    public class KiaomiEBook : IEBook
    {
        public void DisplaySpecs() => Console.WriteLine("Kiaomi Mi Pad - 11 inch, Android tablet");
    }

    // Продукти бренду Balaxy
    public class BalaxyLaptop : ILaptop
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Galaxy Book - 32GB RAM, Intel i9, OLED display");
    }

    public class BalaxySmartphone : ISmartphone
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Galaxy S24 - Exynos 2400, 512GB, 200MP camera");
    }

    public class BalaxyNetbook : INetbook
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Galaxy Book Go - ARM processor, Always connected");
    }

    public class BalaxyEBook : IEBook
    {
        public void DisplaySpecs() => Console.WriteLine("Balaxy Galaxy Tab - 12.4 inch, S Pen included");
    }

    // Абстрактна фабрика
    public interface IDeviceFactory
    {
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
        INetbook CreateNetbook();
        IEBook CreateEBook();
    }

    // Конкретні фабрики
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

    // ===== ЗАВДАННЯ 3: ОДИНАК =====

    public sealed class Authenticator
    {
        private static volatile Authenticator _instance;
        private static readonly object _lock = new object();
        private readonly Dictionary<string, string> _users;

        private Authenticator()
        {
            _users = new Dictionary<string, string>
            {
                { "admin", "password123" },
                { "user", "userpass" },
                { "guest", "guest123" }
            };
            Console.WriteLine("Authenticator instance created");
        }

        public static Authenticator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new Authenticator();
                    }
                }
                return _instance;
            }
        }

        public bool Authenticate(string username, string password)
        {
            return _users.ContainsKey(username) && _users[username] == password;
        }

        public void AddUser(string username, string password)
        {
            _users[username] = password;
        }

        public void DisplayUsers()
        {
            Console.WriteLine("Registered users:");
            foreach (var user in _users.Keys)
            {
                Console.WriteLine($"- {user}");
            }
        }
    }

    // ===== ЗАВДАННЯ 4: ПРОТОТИП =====

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

            // Глибоке клонування дітей
            foreach (var child in Children)
            {
                cloned.AddChild((Virus)child.Clone());
            }

            return cloned;
        }

        public void DisplayInfo(int indent = 0)
        {
            var indentStr = new string(' ', indent * 2);
            Console.WriteLine($"{indentStr}Ім'я: {Name}, Вид: {Species}, Вага: {Weight}г, Вік: {Age} днів");

            foreach (var child in Children)
            {
                child.DisplayInfo(indent + 1);
            }
        }
    }

    // ===== ЗАВДАННЯ 5: БУДІВЕЛЬНИК =====

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

        public void DisplayInfo()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"Зріст: {Height} см");
            Console.WriteLine($"Статура: {Build}");
            Console.WriteLine($"Колір волосся: {HairColor}");
            Console.WriteLine($"Колір очей: {EyeColor}");
            Console.WriteLine($"Одяг: {Clothing}");
            Console.WriteLine($"Світогляд: {Alignment}");

            if (Inventory.Any())
                Console.WriteLine($"Інвентар: {string.Join(", ", Inventory)}");

            if (GoodDeeds.Any())
                Console.WriteLine($"Добрі справи: {string.Join(", ", GoodDeeds)}");

            if (EvilDeeds.Any())
                Console.WriteLine($"Злі справи: {string.Join(", ", EvilDeeds)}");

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
            _character = new Character { Alignment = "Добрий" };
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
            _character = new Character { Alignment = "Злий" };
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
        public Character CreateDreamHero(HeroBuilder builder)
        {
            return ((HeroBuilder)builder.SetName("Артеміс Світлана")
                                       .SetHeight(175)
                                       .SetBuild("Атлетична")
                                       .SetHairColor("Золотисто-русяве")
                                       .SetEyeColor("Сапфірово-сині")
                                       .SetClothing("Сяючі лати з рунами")
                                       .AddInventoryItem("Меч Світанку")
                                       .AddInventoryItem("Щит Надії")
                                       .AddInventoryItem("Зілля лікування"))
                         .AddGoodDeed("Врятувала село від драконів")
                         .AddGoodDeed("Допомогла сиротам знайти дім")
                         .Build();
        }

        public Character CreateArchEnemy(EnemyBuilder builder)
        {
            return ((EnemyBuilder)builder.SetName("Мордус Темнобрів")
                                        .SetHeight(195)
                                        .SetBuild("Загрозлива")
                                        .SetHairColor("Чорне як ніч")
                                        .SetEyeColor("Кривавово-червоні")
                                        .SetClothing("Чорна мантія з шипами")
                                        .AddInventoryItem("Клинок Прокляття")
                                        .AddInventoryItem("Амулет Темряви")
                                        .AddInventoryItem("Отрута душ"))
                         .AddEvilDeed("Знищив цілі міста")
                         .AddEvilDeed("Поневолив драконів")
                         .Build();
        }
    }

    // ===== ГОЛОВНА ПРОГРАМА =====

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ПАТЕРНІВ ПРОЕКТУВАННЯ ===\n");

            // ЗАВДАННЯ 1: Фабричний метод
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

            // ЗАВДАННЯ 2: Абстрактна фабрика
            Console.WriteLine("2. АБСТРАКТНА ФАБРИКА - Виробництво техніки\n");

            var factories = new List<IDeviceFactory>
            {
                new IProneeFactory(),
                new KiaomiFactory(),
                new BalaxyFactory()
            };

            foreach (var factory in factories)
            {
                Console.WriteLine($"Фабрика {factory.GetType().Name}:");
                factory.CreateLaptop().DisplaySpecs();
                factory.CreateSmartphone().DisplaySpecs();
                factory.CreateNetbook().DisplaySpecs();
                factory.CreateEBook().DisplaySpecs();
                Console.WriteLine();
            }

            Console.WriteLine(new string('=', 50) + "\n");

            // ЗАВДАННЯ 3: Одинак
            Console.WriteLine("3. ОДИНАК - Authenticator\n");

            // Тестування в різних потоках
            var tasks = new List<Thread>();

            for (int i = 0; i < 3; i++)
            {
                int threadId = i;
                var thread = new Thread(() =>
                {
                    var auth = Authenticator.Instance;
                    Console.WriteLine($"Thread {threadId}: Authenticator hash = {auth.GetHashCode()}");
                    auth.AddUser($"user{threadId}", $"pass{threadId}");
                });
                tasks.Add(thread);
                thread.Start();
            }

            foreach (var task in tasks)
                task.Join();

            var authenticator = Authenticator.Instance;
            authenticator.DisplayUsers();
            Console.WriteLine($"Authentication test: {authenticator.Authenticate("admin", "password123")}");
            Console.WriteLine();

            Console.WriteLine(new string('=', 50) + "\n");

            // ЗАВДАННЯ 4: Прототип
            Console.WriteLine("4. ПРОТОТИП - Сімейство вірусів\n");

            // Створення сімейства вірусів
            var grandparentVirus = new Virus("COVID-Alpha", "Coronavirus", 0.1, 365);

            var parentVirus1 = new Virus("COVID-Beta", "Coronavirus", 0.08, 180);
            var parentVirus2 = new Virus("COVID-Gamma", "Coronavirus", 0.09, 150);

            var childVirus1 = new Virus("COVID-Delta", "Coronavirus", 0.07, 90);
            var childVirus2 = new Virus("COVID-Omicron", "Coronavirus", 0.06, 60);
            var childVirus3 = new Virus("COVID-Lambda", "Coronavirus", 0.08, 45);

            // Побудова ієрархії
            grandparentVirus.AddChild(parentVirus1);
            grandparentVirus.AddChild(parentVirus2);

            parentVirus1.AddChild(childVirus1);
            parentVirus1.AddChild(childVirus2);
            parentVirus2.AddChild(childVirus3);

            Console.WriteLine("Оригінальне сімейство вірусів:");
            grandparentVirus.DisplayInfo();

            Console.WriteLine("\nКлоноване сімейство вірусів:");
            var clonedVirus = (Virus)grandparentVirus.Clone();
            clonedVirus.DisplayInfo();

            Console.WriteLine(new string('=', 50) + "\n");

            // ЗАВДАННЯ 5: Будівельник
            Console.WriteLine("5. БУДІВЕЛЬНИК - Створення персонажів\n");

            var director = new CharacterDirector();
            var heroBuilder = new HeroBuilder();
            var enemyBuilder = new EnemyBuilder();

            var dreamHero = director.CreateDreamHero(heroBuilder);
            var archEnemy = director.CreateArchEnemy(enemyBuilder);

            Console.WriteLine("Герой мрії:");
            dreamHero.DisplayInfo();

            Console.WriteLine("Заклятий ворог:");
            archEnemy.DisplayInfo();

            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА ===");
        }
    }
}