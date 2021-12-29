using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Animal
    {
        private const string KittenGender = "Female";
        public Kitten(string name, int age, string gender) 
            : base(name, age, KittenGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
