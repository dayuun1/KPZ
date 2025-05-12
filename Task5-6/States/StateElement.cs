using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6.States
{
    public class StateElement : LightElementNode
    {
        private IState _state;

        public StateElement(string tagName) : base(tagName)
        {
            _state = new VisibleState();
        }

        public void SetState(IState newState)
        {
            _state = newState;
        }

        public void ShowState()
        {
            _state.ShowState(this);
        }
    }
}
