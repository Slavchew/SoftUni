using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Animal
    {
        private const string TomcatGender = "Male";
        public Tomcat(string name, int age, string gender) 
            : base(name, age, TomcatGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
