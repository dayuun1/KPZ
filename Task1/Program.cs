using System;
using System.IO;

class Logger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

class FileWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string text)
    {
        File.AppendAllText(_filePath, text);
    }

    public void WriteLine(string text)
    {
        File.AppendAllText(_filePath, text + Environment.NewLine);
    }
}

class FileLoggerAdapter
{
    private readonly FileWriter _fileWriter;

    public FileLoggerAdapter(FileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public void Log(string message)
    {
        _fileWriter.WriteLine("info: " + message);
    }

    public void Error(string message)
    {
        _fileWriter.WriteLine("error: " + message);
    }

    public void Warn(string message)
    {
        _fileWriter.WriteLine("warn: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var logger = new Logger();
        logger.Log("info1");
        logger.Error("error2");
        logger.Warn("warn3");

        var fileWriter = new FileWriter("E:\\Навчання\\КПЗ лаби\\Lab3\\Task1\\log.txt");
        var fileLogger = new FileLoggerAdapter(fileWriter);

        fileLogger.Log("info");
        fileLogger.Error("error");
        fileLogger.Warn("warn");
        Console.WriteLine("logs are recorded ");
    }
}
