using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    public List<LightNode> Children { get; } = new();
    public List<string> CssClasses { get; } = new();

    public LightElementNode(string tagName)
    {
        TagName = tagName;
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }
    public void AddClass(string className)
    {
        CssClasses.Add(className);
    }

    public override string InnerHTML()
    {
        var builder = new StringBuilder();
        foreach (var child in Children)
            builder.Append(child.OuterHTML());
        return builder.ToString();
    }

    public override string OuterHTML()
    {
        string _class = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
        return $"<{TagName}{_class}>{InnerHTML()}</{TagName}>";
    }
}
