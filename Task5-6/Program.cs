using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task5_6;

class Program
{
    static async Task Main(string[] args)
    {
        var div = new LightElementNode("div");
        var hello = new LightTextNode("Hello");
        var span = new LightElementNode("span");
        span.AddChild(new LightTextNode("World"));
        div.AddChild(span);
        div.AddChild(hello);

        var dfs = new DepthIterator();
        foreach (var node in dfs.Scan(div))
            Console.WriteLine(node.OuterHTML());

        Console.WriteLine("----------");

        var bfs = new BreadthIterator();
        foreach (var node in bfs.Scan(div))
            Console.WriteLine(node.OuterHTML());

    }
}