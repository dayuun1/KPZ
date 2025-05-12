using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6.States
{
    public class ErrorState : IState
    {
        public void ShowState(LightNode node)
        {
            Console.WriteLine($"[Error] Problems with {node.GetType().Name}");
        }
    }
}
