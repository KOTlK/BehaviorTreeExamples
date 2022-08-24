using BananaParty.BehaviorTree;
using Examples.Follower;
using UnityEngine;

namespace Examples.Warrior.Behavior
{
    public class Patrol : BehaviorNode
    {
        private readonly Vector2[] _points;
        private readonly IMovingCharacter _origin;

        private int _current = 0;
        private bool _goingBackwards = false;

        public Patrol(Vector2[] points, IMovingCharacter origin)
        {
            _points = points;
            _origin = origin;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _points[_current] - _origin.Position;

            if (direction.sqrMagnitude < 1) Next();

            _origin.Move(direction);
            return BehaviorNodeStatus.Running;
        }

        private void Next()
        {
            if (_current == _points.Length - 1 && _goingBackwards == false) _goingBackwards = true;
            if (_current == 0 && _goingBackwards) _goingBackwards = false;

            if (_goingBackwards == false)
            {
                _current++;
            }
            else
            {
                _current--;
            }
        }
    }
}