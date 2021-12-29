using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Square : Shape
    {
        public int A { get; set; }
        public override double Area()
        {
            return A * A;
        }
    }
}
