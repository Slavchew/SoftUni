using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    public class Animal
    {
        public virtual void Eat(object food)
        {
            Console.WriteLine("Eating the food " + food);
        }
        public virtual void Sleep()
        {
            Console.WriteLine("Sleeping");
        }
    }
}
