using System.Collections.Generic;
using System.Linq;
using BananaParty.BehaviorTree;
using Examples.Follower;
using UnityEngine;

namespace Examples.Warrior.Behavior
{
    public class FindTarget : BehaviorNode
    {
        private readonly float _range;
        private readonly ITarget<AggressiveCharacter> _target;
        private readonly IMovingCharacter _origin;
        private readonly Collider2D[] _results;

        public FindTarget(float range, ITarget<AggressiveCharacter> target, IMovingCharacter origin)
        {
            _range = range;
            _target = target;
            _origin = origin;
            _results = new Collider2D[32];
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_target.HasTarget) return BehaviorNodeStatus.Success;

            if (Physics2D.OverlapCircleNonAlloc(_origin.Position, _range, _results) == 0)
                return BehaviorNodeStatus.Failure;

            var notNull = _results
                .TakeWhile(collider => collider != null);
            

            if (notNull.Any() == false) return BehaviorNodeStatus.Failure;

            var damageable = new List<AggressiveCharacter>();
            
            foreach (var collider in notNull)
            {
                if (collider.TryGetComponent(out AggressiveCharacter target) == false) continue;
                
                if (target != (AggressiveCharacter) _origin && target.IsDead == false)
                {
                    damageable.Add(target);
                }
            }

            if (damageable.Count == 0) return BehaviorNodeStatus.Failure;

            _target.Switch(damageable[0]);
            return BehaviorNodeStatus.Success;
        }

    }
}