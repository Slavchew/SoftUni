using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<Attribute> propertyCustomAttributes = property
                    .GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute);

                foreach (MyValidationAttribute customAttribute in propertyCustomAttributes)
                {
                    bool result = customAttribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }


            return true;
        }
    }
}