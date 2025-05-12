using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task5_6;
using Task5_6.States;

class Program
{
    static async Task Main(string[] args)
    {
        var div = new StateElement("div");
        div.AddChild(new LightTextNode("Dan"));

        div.ShowState(); 

        div.SetState(new HiddenState());
        div.ShowState(); 

        div.SetState(new ErrorState());
        div.ShowState();

        div.SetState(new DisabledState());
        div.ShowState();
    }
}