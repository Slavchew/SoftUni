using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    class MultiplyCommand : ICommand
    {
        public MultiplyCommand(int operand) 
            : base(operand)
        {
        }

        public override int Calculate(int currentValue)
        {
            return currentValue * operand;
        }

        public override int UndoCalculation(int currentValue)
        {
            return currentValue / operand;
        }
    }
}
