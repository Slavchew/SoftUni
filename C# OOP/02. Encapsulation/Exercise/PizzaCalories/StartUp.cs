using System;
using System.Collections.Generic;
using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            try
            {
                CreatePizza(input);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void CreatePizza(string[] input)
        {
            Pizza pizza = new Pizza(input[1]);
            input = Console.ReadLine().Split(" ");
            AddDough(input,pizza);
            input = Console.ReadLine().Split(" ");
            while (input[0] != "END")
            {
                AddTopping(input,pizza);

                input = Console.ReadLine().Split(" ");
            }
            Console.WriteLine(pizza);
        }

        private static void AddDough(string[] input,Pizza pizza)
        {
            var flour = input[1].ToLower();
            var bakingTechnique = input[2].ToLower();
            var weight = double.Parse(input[3]);

            Dough dough = new Dough(flour, bakingTechnique, weight);

            pizza.Dough = dough;
        }

        private static void AddTopping(string[] input, Pizza pizza)
        {
            var type = input[1];
            var grams = double.Parse(input[2]);

            Topping topping = new Topping(type, grams);
            pizza.AddTopping(topping);
        }
    }
}
