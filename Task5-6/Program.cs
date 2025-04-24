using System;
using System.Threading.Tasks;
using Task5_6;

class Program
{
    static async Task Main(string[] args)
    {
        var localImg = new ImageElement("C:/images/photo.jpg", new FileStrategy());
        var webImg = new ImageElement("https://example.com/photo.jpg", new WebStrategy());

        Console.WriteLine(localImg.OuterHTML());
        Console.WriteLine(webImg.OuterHTML());
    }
}