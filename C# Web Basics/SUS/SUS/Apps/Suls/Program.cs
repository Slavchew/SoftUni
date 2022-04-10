using System;
using System.Threading.Tasks;

using SUS.MvcFramework;

namespace Suls
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
