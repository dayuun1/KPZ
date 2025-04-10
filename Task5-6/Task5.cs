using System;
using Task5_6;

public static class Task1
{
    public static void Run()
    {
        var ul = new LightElementNode("ul");
        ul.AddClass("list");

        var li1 = new LightElementNode("li");
        li1.AddChild(new LightTextNode("First item"));
        ul.AddChild(li1);

        var li2 = new LightElementNode("li");
        li2.AddChild(new LightTextNode("Second item"));
        ul.AddChild(li2);

        Console.WriteLine("Task1");
        Console.WriteLine("OuterHTML:");
        Console.WriteLine(ul.OuterHTML());
        Console.WriteLine("\nInnerHTML:");
        Console.WriteLine(ul.InnerHTML());
    }
}
