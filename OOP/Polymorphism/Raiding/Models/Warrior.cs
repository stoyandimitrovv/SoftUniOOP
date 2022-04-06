using Raiding;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        { }

        public override int Power => Constants.PaladinAndWarriorPower;

        public override string CastAbility()
        {
            return string.Format(Constants.StringOverrideRogueWarrior, GetType().Name, Name, Power);
        }
    }
}
