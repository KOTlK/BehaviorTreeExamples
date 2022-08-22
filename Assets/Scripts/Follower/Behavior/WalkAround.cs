using BananaParty.BehaviorTree;
using UnityEngine;

namespace Examples.Follower.Behavior
{
    public class WalkAround : BehaviorNode
    {
        private readonly IMovingCharacter _origin;
        
        private Vector2 _targetPosition;

        private const float MaxDistance = 3f;

        public WalkAround(IMovingCharacter origin)
        {
            _origin = origin;
            _targetPosition = RandomPosition(_origin.Position, MaxDistance);
        }
        
        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status != BehaviorNodeStatus.Running) _targetPosition = RandomPosition(_origin.Position, MaxDistance);
            
            var direction = _targetPosition - _origin.Position;

            if (direction.sqrMagnitude < 1f) return BehaviorNodeStatus.Success;

            _origin.Move(direction);
            return BehaviorNodeStatus.Running;
        }

        private static Vector2 RandomPosition(Vector2 origin, float distance)
        {
            return origin + Random.insideUnitCircle * distance;
        }
    }
}