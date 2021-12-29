using P03.Raiding.Core;
using P03.Raiding.Core.Contracts;

namespace P03.Raiding
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
