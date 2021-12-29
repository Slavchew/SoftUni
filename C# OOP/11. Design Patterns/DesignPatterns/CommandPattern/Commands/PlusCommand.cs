using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    class PlusCommand : ICommand
    {
        public PlusCommand(int operand) 
            : base(operand)
        {
        }

        public override int Calculate(int currentValue)
        {
            return currentValue + operand;
        }

        public override int UndoCalculation(int currentValue)
        {
            return currentValue - operand;
        }
    }
}
