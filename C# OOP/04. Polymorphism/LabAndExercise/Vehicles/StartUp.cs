using System;
using Vehicles.Core;
using Vehicles.Core.Contracts;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
