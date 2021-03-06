namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public virtual int Power { get; private set; }

        public virtual string CastAbility()
        {
            return null;
        }
    }
}
