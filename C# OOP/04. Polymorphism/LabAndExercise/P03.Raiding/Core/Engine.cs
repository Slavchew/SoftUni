using P03.Raiding.Core.Contracts;
using P03.Raiding.Factories;
using P03.Raiding.Models;
using System;
using System.Collections.Generic;

namespace P03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly HeroFactory heroFactory;

        public Engine()
        {
            this.heroFactory = new HeroFactory();
        }

        public void Run()
        {
            List<BaseHero> heroTeam = new List<BaseHero>();
            var n = int.Parse(Console.ReadLine());

            while (heroTeam.Count < n)
            {
                try
                {
                    var currHero = ProcessHeroInfo();
                    heroTeam.Add(currHero);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }


            var bossPower = int.Parse(Console.ReadLine());

            var teamPower = 0;
            foreach (var hero in heroTeam)
            {
                Console.WriteLine(hero.CastAbility());
                teamPower += hero.Power;
            }

            if (teamPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }


        private BaseHero ProcessHeroInfo()
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            BaseHero currHero = this.heroFactory.CreateHero(heroType, heroName);

            return currHero;
        }
    }
}
