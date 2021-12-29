using System;
using System.Text;

namespace Village
{
    public class Rebel : Person
    {
        private const int maxAge = 50;

        private int harm;

        public Rebel(string name, int age, int harm)
            : base(name, age)
        {
            this.Harm = harm;
        }

        public override int Age
        {
            get { return base.Age; }
            protected set
            {
                base.Age = value;
                if (value > maxAge)
                {
                    throw new ArgumentException("Age should be less or equal to 50!");
                }
            }
        }

        public int Harm
        {
            get { return this.harm; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Harm should be greater than 0!");
                }
                this.harm = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Harm: {this.Harm}");

            return sb.ToString().TrimEnd();
        }
    }
}
