using System;

namespace Examples.Warrior
{
    public class Target<T> : ITarget<T>
    where T : class
    {
        public Target(T target = null)
        {
            Current = target;
        }
        
        public bool HasTarget => Current != null;
        public T Current { get; private set; }
        
        public void Switch(T target)
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