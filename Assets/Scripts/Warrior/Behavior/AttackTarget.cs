using BananaParty.BehaviorTree;

namespace Examples.Warrior.Behavior
{
    public class AttackTarget : BehaviorNode
    {
        private readonly ITarget<IAggressiveCharacter> _target;
        private readonly IAggressive _origin;

        public AttackTarget(ITarget<IAggressiveCharacter> target, IAggressive origin)
        {
            _target = target;
            _origin = origin;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_target.HasTarget == false) return BehaviorNodeStatus.Failure;
            if (_target.Current.IsDead)
            {
                _target.Reset();
                return BehaviorNodeStatus.Success;
            }

            _origin.Attack(_target.Current);

            return BehaviorNodeStatus.Success;
        }
    }
}