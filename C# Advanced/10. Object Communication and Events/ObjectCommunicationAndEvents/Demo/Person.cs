using System;
using System.Collections.Generic;

namespace Demo
{
    public class Person
    {
        private string firstName;
        private string lastName;

        private ICollection<IPersonObserver> observers = new List<IPersonObserver>();

        public event EventHandler<PersonPropertyEventArgs> OnPropertyChanged;
        public event EventHandler OnGreeting;

        public string FirstName 
        { 
            get => this.firstName; 
            set
            {
                this.OnPropertyChanged?.Invoke(this, new PersonPropertyEventArgs
                {
                    Property = nameof(FirstName),
                    OldValue = this.firstName,
                    NewValue = value
                });

                this.NotifyObserver(nameof(FirstName));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                this.OnPropertyChanged?.Invoke(this, new PersonPropertyEventArgs
                {
                    Property = nameof(LastName),
                    OldValue = this.lastName,
                    NewValue = value
                });

                this.NotifyObserver(nameof(LastName));

                this.lastName = value;
            }
        }

        public string SayHello()
        {
            this.OnGreeting?.Invoke(this, EventArgs.Empty);
            return $"My name is: {this.firstName} {this.lastName}";
        }

        public void AddObserver(IPersonObserver observer)
        {
            this.observers.Add(observer);
        }

        private void NotifyObserver(string property)
        {
            foreach (var observer in this.observers)
            {
                observer.Handle(property);
            }
        } 
    }
}
