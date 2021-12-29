using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    class Snake : Animal
    {
        public void EatPerson(Human human)
        {

        }
        public override void Eat(object food)
        {
            if (!(food is Program))
            {
                Console.WriteLine("I only eat your programs");
            }
            else
            {
                Console.WriteLine("Programs are yummi");
            }
        }
    }
}
