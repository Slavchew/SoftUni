using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class FootballGame : Game
    {
        private List<Player> team;

        public FootballGame()
        {
            team = new List<Player>();
        }

        public override string GetDiscription()
        {
            return $"The team god mad and got in a fight";
        }

        public override void Start()
        {
            base.Start();
            Console.WriteLine("Football game starting");
            Console.WriteLine("Play himn");
        }

        public override void Stop()
        {
            base.Stop();
            Console.WriteLine("Get in a fight");
        }
    }
}
