using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class DepthIterator : IIterator
    {
        public IEnumerable<LightNode> Scan(LightNode root)
        {
            var stack = new Stack<LightNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                if (current is LightElementNode element)
                {
                    for (int i = element.Children.Count - 1; i >= 0; i--)
                        stack.Push(element.Children[i]);
                }
            }
        }
    }
}
