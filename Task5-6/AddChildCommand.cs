using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Add()
        {
            _parent.AddChild(_child);
        }

        public void Remove()
        {
            _parent.Children.Remove(_child);
        }
    }

}
