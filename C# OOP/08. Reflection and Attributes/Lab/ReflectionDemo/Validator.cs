using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo
{
    public class Validator
    {
        public static bool Validate(Person person)
        {
            foreach (var property in person.GetType().GetProperties())
            {
                var rangeAttributes = property.GetCustomAttributes(typeof(RangeAttribute), true);

                var currentPropertyValue = property.GetValue(person);

                foreach (var att in rangeAttributes)
                {
                    var isValid = ((RangeAttribute)att).IsValid((int)currentPropertyValue);

                    if (isValid)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
