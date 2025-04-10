using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Task1.Run();
        await Task2.RunAsync();
    }
}