using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Task5_6;

public class LightElementNode : LightNode
{
    public string TagName { get; }
    public List<LightNode> Children { get; } = new();
    public List<string> CssClasses { get; } = new();

    public LightElementNode(string tagName)
    {
        TagName = tagName;
        OnCreated();
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
        child.OnInserted();
    }
    public void AddClass(string className)
    {
        CssClasses.Add(className);
        OnClassListApplied();
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
        OnStylesApplied();
        string _class = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
        return $"<{TagName}{_class}>{InnerHTML()}</{TagName}>";
    }
    public override void OnTextRendered()
    {
        foreach (var child in Children)
            child.OnTextRendered();
    }
    public override void Accept(IVisitor visitor)
    {
        visitor.VisitElementNode(this);
        foreach (var child in Children)
            child.Accept(visitor); 
    }
}
