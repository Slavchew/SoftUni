using System;
using System.Linq;
using System.Collections.Generic;

using P04.WildFarm.Core.Contracts;
using P04.WildFarm.Factories;
using P04.WildFarm.Models.Animals;
using P04.WildFarm.Models.Foods;

namespace P04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new HashSet<Animal>();

            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End" )
            {
                string[] animalArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string[] args = animalArgs.Skip(3).ToArray();

                Animal animal = null;
                try
                {
                    animal = this.animalFactory.Create(type, name, weight, args);

                    this.animals.Add(animal);

                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);

                try
                {
                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    animal?.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
