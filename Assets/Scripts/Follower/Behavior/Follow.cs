using BananaParty.BehaviorTree;

namespace Examples.Follower.Behavior
{
    public class Follow : BehaviorNode
    {
        private readonly IMovingCharacter _origin;
        private readonly IMovingCharacter _target;

        private const float MinDistance = 0;
        private const float MaxDistance = 5f;

        public Follow(IMovingCharacter origin, IMovingCharacter target)
        {
            _origin = origin;
            _target = target;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _target.Position - _origin.Position;

            if (direction.magnitude is > MinDistance and < MaxDistance) return BehaviorNodeStatus.Success;

            _origin.Move(direction);
            return BehaviorNodeStatus.Running;
        }
    }
}