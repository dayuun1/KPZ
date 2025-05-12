using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class BreadthIterator : IIterator
    {
        public IEnumerable<LightNode> Scan(LightNode root)
        {
            var queue = new Queue<LightNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current;

                if (current is LightElementNode element)
                {
                    foreach (var child in element.Children)
                        queue.Enqueue(child);
                }
            }
        }
    }
}
