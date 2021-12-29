using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver teamLead = new TeamLead();
            Approver cto = new CTO();

            teamLead.SetNext(cto);

            Console.WriteLine(teamLead.HandleRequest(3));
        }
    }
}
