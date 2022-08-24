namespace Examples.Warrior
{
    public interface ITarget<TTarget>
    {
        bool HasTarget { get; }
        TTarget Current { get; }
        void Switch(TTarget target);
        void Reset();
    }
}