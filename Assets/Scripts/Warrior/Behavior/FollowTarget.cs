using BananaParty.BehaviorTree;
using Examples.Follower;

namespace Examples.Warrior.Behavior
{
    public class FollowTarget : BehaviorNode
    {
        private readonly ITarget<IAggressiveCharacter> _target;
        private readonly IMovingCharacter _origin;

        private const float MinDistance = 2f;
        private const float MaxDistance = 100f;

        public FollowTarget(ITarget<IAggressiveCharacter> target, IMovingCharacter origin)
        {
            _target = target;
            _origin = origin;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_target.HasTarget == false) return BehaviorNodeStatus.Failure;
            
            var direction = _target.Current.Position - _origin.Position;

            if (direction.sqrMagnitude > MaxDistance) return BehaviorNodeStatus.Failure;

            if (direction.sqrMagnitude > MinDistance)
            {
                _origin.Move(direction);
            }

            return BehaviorNodeStatus.Running;
        }
    }
}