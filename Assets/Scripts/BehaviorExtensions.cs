using BananaParty.BehaviorTree;

namespace Examples.Extensions
{
    public static class BehaviorExtensions
    {
        public static IBehaviorNode Repeat(this IBehaviorNode node)
        {
            return new RepeatNode(node);
        }

        public static IBehaviorNode RepeatUntilFailure(this IBehaviorNode node)
        {
            return new RepeatNode(node, BehaviorNodeStatus.Failure);
        }

        public static IBehaviorNode RepeatUntilSuccess(this IBehaviorNode node)
        {
            return new RepeatNode(node, BehaviorNodeStatus.Success);
        }

        public static IBehaviorNode Invert(this IBehaviorNode node)
        {
            return new InverterNode(node);
        }
    }
}