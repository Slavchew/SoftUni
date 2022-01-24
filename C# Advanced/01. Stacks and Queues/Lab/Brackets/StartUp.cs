using System;
using System.Collections.Generic;

namespace Brackets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> indexes = new Stack<int>();

            string expression = Console.ReadLine();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    var startIndex = indexes.Pop();
                    var length = i - startIndex + 1;
                    string substr = expression.Substring(startIndex, length);
                    Console.WriteLine(substr);
                }
            }
        }
    }
}
