using Raiding;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        { }

        public override int Power => Constants.RogueAndDruidPower;

        public override string CastAbility()
        {
            return string.Format(Constants.StringOverrideDruidPaladin, GetType().Name, Name, Power);
        }
    }
}
