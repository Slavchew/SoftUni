using System;
using System.Collections.Generic;
using System.Text;

namespace Animal
{
    class Human
    {
        public Animal Pet { get; set; }

        public Human(Animal pet)
        {
            this.Pet = pet;
        }
        public void Feed()
        {
            if (Pet is Snake)
            {
                ((Snake)Pet).EatPerson(this);
                (Pet as Snake).EatPerson(this);
                Snake snake = Pet as Snake;
                return;
            }

            if (Pet is Talasym)
            {
                Console.WriteLine("Feeding the talasym");
                Pet.Eat(new Program());
                return;
            }

            Pet.Eat("Qj be");
        }

        public void PutToSleep()
        {
            Pet.Sleep();
        }
    }
}
