using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Child
    {
        public Child(string childName, string childBirthDay)
        {
            ChildName = childName;
            ChildBirthDay = childBirthDay;
        }

        public string ChildName { get; set; }
        public string ChildBirthDay { get; set; }

        public override string ToString()
        {
            return $"{ChildName} {ChildBirthDay}";
        }
    }
}
