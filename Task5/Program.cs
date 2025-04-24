public class TextDocument
{
    public string Content { get; set; } = string.Empty;

    public override string ToString() => Content;
}

public class DocumentMemento
{
    public string State { get; }

    public DocumentMemento(string state)
    {
        State = state;
    }
}

public class TextEditor
{
    private TextDocument _document = new TextDocument();
    private Stack<DocumentMemento> _history = new();

    public void Type(string text)
    {
        Save();
        _document.Content += text;
    }

    public void Save()
    {
        _history.Push(new DocumentMemento(_document.Content));
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            var memento = _history.Pop();
            _document.Content = memento.State;
        }
        else
        {
            Console.WriteLine("Немає попередніх станів для скасування.");
        }
    }

    public void Print()
    {
        Console.WriteLine($"Поточний документ: {_document}");
    }
}

public class Program
{
    public static void Main()
    {
        var editor = new TextEditor();

        editor.Type("Перший рядок\n");
        editor.Print();

        editor.Type("Другий рядок.\n");
        editor.Print();

        editor.Undo();
        editor.Print();

        editor.Undo();
        editor.Print();
    }
}