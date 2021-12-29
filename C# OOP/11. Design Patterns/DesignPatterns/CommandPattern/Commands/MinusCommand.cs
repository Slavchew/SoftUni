using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    class MinusCommand : ICommand
    {
        public MinusCommand(int operand) 
            : base(operand)
        {
        }

        public override int Calculate(int currentValue)
        {
            return currentValue - operand;
        }

        public override int UndoCalculation(int currentValue)
        {
            return currentValue + operand;
        }
    }
}
