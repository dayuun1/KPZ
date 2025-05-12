using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class CommandController
    {
        private readonly Stack<ICommand> _history = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Add();
            _history.Push(command);
        }

        public void UndoLast()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Remove();
            }
        }
    }
}
