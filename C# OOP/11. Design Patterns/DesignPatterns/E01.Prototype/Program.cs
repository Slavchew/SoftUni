using System;

namespace E01.Prototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Drink drink = new Drink("Coke");
            Sandwich sandwich = new Sandwich("bql", "pueshko", "topeno sirene", "krastavici", drink);

            Sandwich sandwich2 = sandwich.ShallowCopy();
            Sandwich sandwich3 = sandwich.DeepCopy();

            Console.WriteLine("Original: " + sandwich);
            Console.WriteLine("Shallow copy: " + sandwich2);
            Console.WriteLine("Deep copy: " + sandwich3);
            Console.WriteLine();

            sandwich.Bread = "123";
            sandwich.Meat = "123";
            sandwich.Cheese = "123";
            sandwich.Veggies = "123";
            sandwich.Drink.Name = "Pepsi";

            Sandwich sandwich4 = sandwich.ShallowCopy();


            Console.WriteLine("Original: " + sandwich);
            Console.WriteLine("Shallow copy: " + sandwich2);
            Console.WriteLine("Deep copy: " + sandwich3);
            Console.WriteLine("Shallow copy2: " + sandwich4);

        }
    }
}
