using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Parent
    {
        public Parent(string parentName, string parentBirthDay)
        {
            ParentName = parentName;
            ParentBirthDay = parentBirthDay;
        }

        public string ParentName { get; set; }
        public string ParentBirthDay { get; set; }

        public override string ToString()
        {
            return $"{this.ParentName} {this.ParentBirthDay}";
        }
    }
}
