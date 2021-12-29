using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    class Talasym : Animal
    {
        public override void Eat(object food)
        {
            Console.WriteLine("Talysymstvam");
        }

        public override void Sleep()
        {
            Console.WriteLine("Talysymstvam speiki");
        }
    }
}
