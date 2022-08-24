namespace Examples.Warrior
{
    public interface IDamageable
    {
        bool IsDead { get; }
        void ApplyDamage(float amount);
    }
}