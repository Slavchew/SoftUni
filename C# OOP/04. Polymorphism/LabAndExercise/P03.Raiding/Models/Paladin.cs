namespace P03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) 
            : base(name)
        {
        }

        public override int Power => base.Power + PaladinPower;

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {this.Power}";
        }
    }
}
