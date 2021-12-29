
using System;
using System.Collections.Generic;
using System.Text;

namespace LazyLoading
{
    class Cart
    {
        public Cart()
        {
            Console.WriteLine("Initalized");
        }

        public int Balance { get; set; }
    }
}
