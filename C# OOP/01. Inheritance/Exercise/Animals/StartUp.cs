using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animalType = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (animalType != "Beast!")
            {
                try
                {
                    var animalInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var animalName = animalInput[0];
                    var animalAge = int.Parse(animalInput[1]);
                    var animalGender = animalInput[2];

                    if (animalType == "Cat")
                    {
                        Cat cat = new Cat(animalName, animalAge, animalGender);
                        animals.Add(cat);
                    }
                    else if (animalType == "Dog")
                    {
                        Dog cat = new Dog(animalName, animalAge, animalGender);
                        animals.Add(cat);
                    }
                    else if (animalType == "Frog")
                    {
                        Frog cat = new Frog(animalName, animalAge, animalGender);
                        animals.Add(cat);
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten cat = new Kitten(animalName, animalAge, animalGender);
                        animals.Add(cat);
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat cat = new Tomcat(animalName, animalAge, animalGender);
                        animals.Add(cat);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
                animalType = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
