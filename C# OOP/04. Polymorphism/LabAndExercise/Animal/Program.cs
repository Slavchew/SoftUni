using System;

namespace Animal
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Snake();
            Snake snake = animal as Snake;

            if (animal is Snake)
            {
                Console.WriteLine("Zyma");
            }
            if (animal is Cat)
            {
                Console.WriteLine("Keta");
            }

            Animal animal2 = new Cat();

            Human catLover = new Human(animal);
            Human snakeHater = new Human(animal);

            while (true)
            {
                Console.ReadLine();
                
                catLover.Feed();
                catLover.PutToSleep();

                //snakeHater.Feed();
                //snakeHater.PutToSleep();
            }
        }
    }
}
