using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task5_6;
using Task5_6.States;

class Program
{
    static async Task Main(string[] args)
    {
        var div = new LightElementNode("div");
        div.AddChild(new LightTextNode("Hello"));
        div.AddChild(new ImageElement("logo.png", new FileStrategy()));
        div.AddChild(new LightElementNode("p"));

        var counter = new CountVisitor();
        div.Accept(counter);

        Console.WriteLine($"Text: {counter.TextNodeCount}, Elements: {counter.ElementNodeCount}, Images: {counter.ImageNodeCount}");

    }
}