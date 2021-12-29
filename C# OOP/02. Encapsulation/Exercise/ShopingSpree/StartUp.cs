using System;

using ShopingSpree.Core;
using ShopingSpree.Models;

namespace ShopingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
