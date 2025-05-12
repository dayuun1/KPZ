using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class CountVisitor : IVisitor
    {
        public int TextNodeCount { get; private set; }
        public int ElementNodeCount { get; private set; }
        public int ImageNodeCount { get; private set; }

        public void VisitTextNode(LightTextNode textNode)
        {
            TextNodeCount++;
        }

        public void VisitElementNode(LightElementNode elementNode)
        {
            ElementNodeCount++;
        }

        public void VisitImageNode(ImageElement imageNode)
        {
            ImageNodeCount++;
        }
    }
}
