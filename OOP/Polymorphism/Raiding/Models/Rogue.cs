using Raiding;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        { }

        public override int Power => Constants.RogueAndDruidPower;

        public override string CastAbility()
        {
            return string.Format(Constants.StringOverrideRogueWarrior, GetType().Name, Name, Power);
        }
    }
}