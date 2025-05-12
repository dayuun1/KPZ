using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class LifecycleTestNode : LightElementNode
    {
        public LifecycleTestNode(string tagName) : base(tagName) { }

        public override void OnCreated()
        {
            Console.WriteLine($"[{TagName}] Created");
        }

        public override void OnInserted()
        {
            Console.WriteLine($"[{TagName}] Inserted");
        }

        public override void OnTextRendered()
        {
            Console.WriteLine($"[{TagName}] Text Rendered");
        }
    }
}
