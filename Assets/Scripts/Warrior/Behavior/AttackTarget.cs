using BananaParty.BehaviorTree;
using UnityEngine;

namespace Examples.Warrior.Behavior
{
    public class AttackTarget : BehaviorNode
    {
        private readonly ITarget<AggressiveCharacter> _target;
        private readonly IAggressive _origin;

        public AttackTarget(ITarget<AggressiveCharacter> target, IAggressive origin)
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
                return BehaviorNodeStatus.Failure;
            }

            _origin.Attack(_target.Current);
            Debug.Log("Attacking " + _target.Current);

            return BehaviorNodeStatus.Success;
        }
    }
}