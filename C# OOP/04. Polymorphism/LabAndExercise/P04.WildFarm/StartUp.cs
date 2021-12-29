using P04.WildFarm.Core;
using P04.WildFarm.Core.Contracts;
using System;

namespace P04.WildFarm
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
