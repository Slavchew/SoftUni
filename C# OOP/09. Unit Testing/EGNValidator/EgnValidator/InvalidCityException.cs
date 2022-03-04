using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator
{
    public class InvalidCityException : Exception
    {
        public InvalidCityException(string cityName)
        {
            CityName = cityName;
        }

        public string CityName { get; }
    }
}
