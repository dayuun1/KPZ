using System;
using System.Threading.Tasks;
using Task5_6;

class Program
{
    static async Task Main(string[] args)
    {
        var div = new LifecycleTestNode("div");
        div.AddClass("container");

        var text = new LifecycleTestNode("Hello, World!");
        div.AddChild(text);

        div.LifecycleHooks();
    }
}