using BananaParty.BehaviorTree;
using Examples.Extensions;
using Examples.Follower.Behavior;

namespace Examples.Follower
{
    public class FollowingCharacter : MovingCharacter, IBehavior
    {
        private IBehaviorNode _behavior;

        public void Init(IMovingCharacter target)
        {
            _behavior = new SequenceNode(new IBehaviorNode[]
            {
                new Follow(this, target),
                
                new SequenceNode(new IBehaviorNode[]
                    {
                        new WalkAround(this),
                        new WaitNode(500)
                    })
            }).Repeat();
        }

        public void Execute(long time)
        {
            _behavior.Execute(time);
        }

        public void VisualizeTree(ITreeGraph<IReadOnlyBehaviorNode> graphView)
        {
            _behavior.WriteToGraph(graphView);
        }
    }
}