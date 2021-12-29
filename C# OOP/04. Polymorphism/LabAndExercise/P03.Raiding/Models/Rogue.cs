namespace P03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;
        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power => base.Power + RoguePower;
        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }
    }
}
