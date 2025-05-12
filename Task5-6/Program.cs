using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task5_6;

class Program
{
    static async Task Main(string[] args)
    {
        var div = new LightElementNode("div");
        var span = new LightElementNode("span");

        var controller = new CommandController();
        controller.ExecuteCommand(new AddChildCommand(div, span));
        controller.ExecuteCommand(new AddClassCommand(div, "first"));
        Console.WriteLine(div.OuterHTML());
        controller.UndoLast(); 
        Console.WriteLine(div.OuterHTML());

    }
}