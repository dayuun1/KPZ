using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public interface IVisitor
    {
        void VisitTextNode(LightTextNode textNode);
        void VisitElementNode(LightElementNode elementNode);
        void VisitImageNode(ImageElement imageNode);
    }
}
