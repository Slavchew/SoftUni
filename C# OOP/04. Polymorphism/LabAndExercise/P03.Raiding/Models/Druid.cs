namespace P03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;

        public Druid(string name) 
            : base(name)
        {
        }

        public override int Power => base.Power + DruidPower;

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {this.Power}";
        }
    }
}
