using System;

namespace Examples.Warrior
{
    public class Target : ITarget<IAggressiveCharacter>
    {
        public Target(IAggressiveCharacter target = null)
        {
            Current = target;
        }
        
        public bool HasTarget => Current != null;
        public IAggressiveCharacter Current { get; private set; }
        
        public void Switch(IAggressiveCharacter target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target),
                    $"{nameof(target)} can't be null, use {nameof(Reset)} instead");
            Current = target;
        }

        public void Reset()
        {
            Current = null;
        }
    }
}