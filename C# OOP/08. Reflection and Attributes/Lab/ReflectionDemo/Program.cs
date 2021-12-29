using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Age = 20
            };

            var isValid = Validator.Validate(person);

            Console.WriteLine(isValid);
        }
    }
}
