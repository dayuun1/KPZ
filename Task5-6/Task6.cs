using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Task5_6;

public static class Task2
{
    public static async Task RunAsync()
    {
        string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        var httpClient = new HttpClient();
        var text = await httpClient.GetStringAsync(url);
        var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

        var factory = new ElementFactory();
        var root = new LightElementNode("div");

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i].TrimEnd();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string tag = i == 0 ? "h1"
                       : line.Length < 20 ? "h2"
                       : char.IsWhiteSpace(lines[i][0]) ? "blockquote"
                       : "p";

            var element = new LightElementNode(tag);
            element.AddChild(new LightTextNode(line));
            root.AddChild(element);
        }

        Console.WriteLine("Task6");
        Console.WriteLine(root.OuterHTML());

        Process proc = Process.GetCurrentProcess();
        Console.WriteLine($"Memory used: {proc.PrivateMemorySize64 / 1024} KB");
    }
}
