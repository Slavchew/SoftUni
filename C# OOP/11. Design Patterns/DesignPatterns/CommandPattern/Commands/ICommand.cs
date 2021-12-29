using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    abstract class ICommand
    {
        protected int operand;

        protected ICommand(int operand)
        {
            this.operand = operand;
        }

        public abstract int Calculate(int currentValue);

        public abstract int UndoCalculation(int currentValue);
    }
}
