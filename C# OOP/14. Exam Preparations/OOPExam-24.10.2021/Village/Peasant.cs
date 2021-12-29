using System;
using System.Text;

namespace Village
{
    public class Peasant : Person
    {
        private const int maxAge = 110;

        private int productivity;

        public Peasant(string name, int age, int productivity)
            : base(name, age)
        {
            this.Productivity = productivity;
        }

        public override int Age
        {
            get { return base.Age; }
            protected set
            {
                base.Age = value;
                if (value > maxAge)
                {
                    throw new ArgumentException("Age cannot be greater than 110!");
                }
            }
        }

        public int Productivity
        {
            get { return this.productivity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Productivity cannot be less or equal to 0!");
                }
                this.productivity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Productivity: {this.Productivity}");

            return sb.ToString().TrimEnd();
        }

    }
}
