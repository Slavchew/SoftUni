using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Samsung
{
    public class SamsungTablet : ITablet
    {
        public string OS { get; set; }
    }
}
