namespace Examples.Warrior.Health
{
    public interface IHealth
    {
        bool IsOver { get; }
        void Lose(float amount);
        void Restore(float amount);
    }
}