namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in parentheses)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    if (c == '}')
                    {
                        if (stack.Pop() != '{')
                        {
                            return false;
                        }
                    }
                    else if (c == ']')
                    {
                        if (stack.Pop() != '[')
                        {
                            return false;
                        }
                    }
                    else if (c == ')')
                    {
                        if (stack.Pop() != '(')
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
