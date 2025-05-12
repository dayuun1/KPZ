using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_6;

public abstract class LightNode
{
    public abstract void Accept(IVisitor visitor);
    public virtual void OnCreated() { }
    public virtual void OnInserted() { }
    public virtual void OnRemoved() { }
    public virtual void OnStylesApplied() { }
    public virtual void OnClassListApplied() { }
    public virtual void OnTextRendered() { }

    public void LifecycleHooks()
    {
        OnCreated();
        OnInserted();
        OnStylesApplied();
        OnClassListApplied();
        OnTextRendered();
    }
    public abstract string OuterHTML();
    public abstract string InnerHTML();
}
