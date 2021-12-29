using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    class CTO : Approver
    {
        public override bool HandleRequest(int amount)
        {
            if (amount < 500)
            {
                Console.WriteLine("Vzemi si ot kompani");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
