using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    class Address : ICloneable
    {
        public City City { get; set; }

        public Country Country { get; set; }

        public string Street { get; set; }

        public object Clone()
        {
            var clone = (Address)this.MemberwiseClone();
            clone.City = (City)City.Clone();
            clone.Country = (Country)Country.Clone();

            return clone;
        }

        public override string ToString()
        {
            return $"Country - {this.Country.Name}, City - {this.City.Name}, Street {this.Street}";
        }
    }
}
