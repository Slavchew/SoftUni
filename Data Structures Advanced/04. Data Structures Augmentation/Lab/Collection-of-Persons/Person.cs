using System;

namespace Collection_of_Persons
{
    public class Person : IComparable<Person>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            return Email.CompareTo(other.Email);
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }

            return other.Age == this.Age &&
                other.Name == this.Name &&
                other.Town == this.Town &&
                other.Email == this.Email;
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }
    }
}
