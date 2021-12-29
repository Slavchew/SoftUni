using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    class Calculator
    {
        private List<ICommand> commands = new List<ICommand>();
        private int index = -1;

        public int Result { get; set; }

        public void AddCommand(ICommand command)
        {
            commands.Insert(++index, command);
            Result = commands[index].Calculate(Result);
        }

        public void Undo(int level)
        {
            for (int i = 0; i < level; i++)
            {
                if (index >= 0)
                {
                    Result = commands[index].UndoCalculation(Result);
                    index--;
                }
            }
        }

        public void Redo(int level)
        {
            for (int i = 0; i < level; i++)
            {
                if (index + 1 < commands.Count)
                {
                    index++;
                    Result = commands[index].Calculate(Result);
                }
            }
        }
    }
}
