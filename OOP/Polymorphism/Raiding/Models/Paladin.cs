using Raiding;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        { }

        public override int Power => Constants.PaladinAndWarriorPower;

        public override string CastAbility()
        {
            return string.Format(Constants.StringOverrideDruidPaladin, GetType().Name, Name, Power);
        }
    }
}