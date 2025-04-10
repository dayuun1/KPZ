using System.Collections.Generic;

public class ElementFactory
{
    private readonly Dictionary<string, LightElementNode> _elements = new();

    public LightElementNode GetElement(string tagName)
    {
        if (!_elements.ContainsKey(tagName))
            _elements[tagName] = new LightElementNode(tagName);
        return _elements[tagName];
    }
}