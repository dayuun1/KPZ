using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

interface ISmartTextReader
{
    char[][] ToArr(string filePath);
}

class SmartTextReader : ISmartTextReader
{
    public char[][] ToArr(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var arr = new char[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            arr[i] = lines[i].ToCharArray();
        }

        return arr;
    }
}

class SmartTextChecker : ISmartTextReader
{
    private readonly ISmartTextReader _reader;

    public SmartTextChecker(ISmartTextReader reader)
    {
        _reader = reader;
    }

    public char[][] ToArr(string path)
    {
        Console.WriteLine($"Opening file: {path}");

        var arr = _reader.ToArr(path);
        int totalLines = arr.Length;
        int totalChars = 0;

        foreach (var line in arr)
        {
            totalChars += line.Length;
        }

        Console.WriteLine($"Read successful. File has {totalLines} lines and {totalChars} characters");
        Console.WriteLine($"Closing file: {path}");

        return arr;
    }
}

class SmartTextReaderLocker : ISmartTextReader
{
    private readonly ISmartTextReader _reader;
    private readonly Regex _deniedPath;

    public SmartTextReaderLocker(ISmartTextReader reader, string path)
    {
        _reader = reader;
        _deniedPath = new Regex(path, RegexOptions.IgnoreCase);
    }

    public char[][] ToArr(string filePath)
    {
        if (_deniedPath.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return null;
        }

        return _reader.ToArr(filePath);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string file = "path.txt";
        File.WriteAllLines(file, new string[]
        {
            "KPZ",
            "Lab 3",
            "Hello World"
        });

        ISmartTextReader reader = new SmartTextReader();
        reader.ToArr(file);

        ISmartTextReader checker = new SmartTextChecker(new SmartTextReader());
        checker.ToArr(file);

        ISmartTextReader locker = new SmartTextReaderLocker(new SmartTextReader(), @"^.*blocked\.txt$");
        locker.ToArr("blocked.txt");
        locker.ToArr(file);
    }
}
