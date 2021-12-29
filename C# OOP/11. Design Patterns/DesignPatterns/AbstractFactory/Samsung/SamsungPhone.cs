using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Samsung
{
    public class SamsungPhone : IMobilePhone
    {
        public int Number { get; set; }
    }
}
