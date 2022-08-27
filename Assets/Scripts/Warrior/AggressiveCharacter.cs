using System;
using System.Linq;
using BananaParty.BehaviorTree;
using Examples.Follower;
using Examples.Follower.Behavior;
using Examples.Warrior.Behavior;
using Examples.Warrior.Health;
using UnityEngine;

namespace Examples.Warrior
{
    public class AggressiveCharacter : MovingCharacter, IAggressiveCharacter, IBehavior
    {
        [SerializeField] private float _damage = 10f;
        [SerializeField] private long _attackDelay = 3000;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _targetFindRange = 5f;
        [SerializeField] private Transform[] _patrolWay;

        private IHealth _health;
        private ITarget<AggressiveCharacter> _target;
        private IBehaviorNode _behavior;

        public bool IsDead => _health.IsOver;

        private void Start()
        {
            _health = new Health.Health(_maxHealth);
            _target = new Target<AggressiveCharacter>();

            var points = _patrolWay.Select(trans => (Vector2)trans.position).ToArray();

            _behavior = new SelectorNode(new IBehaviorNode[]
            {
                new ParallelSelectorNode(new IBehaviorNode[]
                {
                    new FindTarget(_targetFindRange, _target, this).RepeatUntilSuccess(),
                    new Patrol(points, this)
                }).Invert(),
                
                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new SequenceNode(new IBehaviorNode[]
                    {
                        new AttackTarget(_target, this),
                        new WaitNode(_attackDelay)
                    }).RepeatUntilFailure(),
                    new FollowTarget(_target, this)
                })
            }).Repeat();
        }

        public void ApplyDamage(float amount) => _health.Lose(amount);
        
        public void Attack(IDamageable target)
        {
            target.ApplyDamage(_damage);
        }

        public void Execute(long time)
        {
            _behavior.Execute(time);
        }

        public void VisualizeTree(ITreeGraph<IReadOnlyBehaviorNode> graph)
        {
            _behavior.WriteToGraph(graph);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(Position, _targetFindRange);
        }
    }
}