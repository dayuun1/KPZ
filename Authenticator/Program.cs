public sealed class Authenticator
{
    private static volatile Authenticator _instance;
    private static readonly object _lock = new object();
    private readonly Dictionary<string, string> _users;

    private Authenticator()
    {
        _users = new Dictionary<string, string>
            {
                { "admin", "admin123" },
                { "user", "password" },
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
            Console.WriteLine($"{user}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            var tasks = new List<Thread>();

            for (int i = 0; i < 3; i++)
            {
                int threadId = i;
                var thread = new Thread(() =>
                {
                    var auth = Authenticator.Instance;
                    auth.AddUser($"user{threadId}", $"pass{threadId}");
                });
                tasks.Add(thread);
                thread.Start();
            }

            foreach (var task in tasks)
                task.Join();

            var authenticator = Authenticator.Instance;
            authenticator.DisplayUsers();
            Console.WriteLine($"Authentication test: {authenticator.Authenticate("admin", "admin123")}");
            

        }
    }
}