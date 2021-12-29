using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    class TeamLead : Approver
    {
        public override bool HandleRequest(int amount)
        {
            if (amount < 5)
            {
                Console.WriteLine("eto to ot moite li4ni");
                return true;
            }
            else
            {
                return Next.HandleRequest(amount);
            }
        }
    }
}
