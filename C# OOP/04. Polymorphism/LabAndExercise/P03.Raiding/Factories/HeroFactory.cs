using System;
using P03.Raiding.Models;

namespace P03.Raiding.Factories
{
    public class HeroFactory
    {
        public HeroFactory()
        {

        }

        public BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero hero;
            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero!");
            }


            return hero;
        }
    }
}
