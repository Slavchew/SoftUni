using System;

namespace Demo
{
    public delegate int SomeDelegateWithNumbers(int a, int b);

    public class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person
            {
                FirstName = "Ivan",
                LastName = "Pesho"
            };

            person.AddObserver(new ConsoleWriteLinePersonObserver());

            person.OnPropertyChanged += (human, eventData) =>
            {
                Console.WriteLine($"Person property ({eventData.Property}) changed from '{eventData.OldValue}' to '{eventData.NewValue}'!");
            };

            person.FirstName = "Gosho";

            person.FirstName = "Ivan";
            person.LastName = "Ivanov";



            person.OnGreeting += (human, eventData) =>
            {
                Console.WriteLine("Person greeting!");
            };

            Console.WriteLine(person.SayHello());
        }
    }
}
