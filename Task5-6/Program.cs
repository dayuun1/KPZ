using System;
using System.Threading.Tasks;
using Task5_6;

class Program
{
    static async Task Main(string[] args)
    {
        var div = new LightElementNode("div");
        div.AddClass("container");
        div.AddChild(new LightTextNode("Натисніть сюди"));
        div.AddEventListener("click", () => Console.WriteLine("Div натиснуто"));

        Console.WriteLine(div.OuterHTML());
        div.TriggerEvent("click");
    }
}