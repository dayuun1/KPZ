abstract class SupportHandler
{
    protected SupportHandler next;

    public void SetNext(SupportHandler nextHandler)
    {
        next = nextHandler;
    }

    public abstract bool HandleRequest(int level);
}

class Level1Support : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 1)
        {
            Console.WriteLine("Підключено до сервера(1 рівень).");
            return true;
        }
        else if (next != null)
        {
            return next.HandleRequest(level);
        }
        return false;
    }
}

class Level2Support : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        
        if (level == 2)
        {
            Console.WriteLine("Надіслано запит(2 рівень).");
            return true;
        }
        else if (next != null)
        {
            return next.HandleRequest(level);
        }
        return false;
    }
}

class Level3Support : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 3)
        {
            Console.WriteLine("Оброблено запит(3 рівень).");
            return true;
        }
        else if (next != null)
        {
            return next.HandleRequest(level);
        }
        return false;
    }
}

class Level4Support : SupportHandler
{
    public override bool HandleRequest(int level)
    {
        if (level == 4)
        {
            Console.WriteLine("Прочитано відповідь(4 рівень).");
            return true;
        }
        else if (next != null)
        {
            return next.HandleRequest(level);
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var level1 = new Level1Support();
        var level2 = new Level2Support();
        var level3 = new Level3Support();
        var level4 = new Level4Support();

        level1.SetNext(level2);
        level2.SetNext(level4);
        level3.SetNext(level4);

        while (true)
        {
            Console.WriteLine("Служба підключень:");
            Console.WriteLine("1 - Підключитись до сервера");
            Console.WriteLine("2 - Надіслати запит");
            Console.WriteLine("3 - Обробити відповідь");
            Console.WriteLine("4 - Прочитати відповідь");
            Console.WriteLine("Оберіть опцію:");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 4)
            {
                bool handled = level1.HandleRequest(choice);
                if (handled)
                    break;
            }
            else
            {
                Console.WriteLine("Спробуйте ще раз.");
            }

            Console.WriteLine("Не підібрано жодного рівня\n");
        }
    }
}