namespace P03.Raiding.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual int Power { get; private set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} ";
        }
    }
}
