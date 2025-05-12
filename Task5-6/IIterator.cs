using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public interface IIterator
    {
        IEnumerable<LightNode> Scan(LightNode root);
    }
}
