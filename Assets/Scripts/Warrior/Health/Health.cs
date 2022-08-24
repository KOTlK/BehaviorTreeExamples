using System;
using UnityEngine;

namespace Examples.Warrior.Health
{
    public class Health : IHealth
    {
        private float _current;
        private readonly float _max;
        private readonly float _min;

        public Health(float max, float min = 0)
        {
            _max = max;
            _min = min;
            _current = _max;
        }

        public bool IsOver => _current == 0;
        
        public void Lose(float amount)
        {
            if (IsOver) throw new ArgumentException("Health is already over");
            SetCurrent(_current - amount);
        }

        public void Restore(float amount)
        {
            SetCurrent(_current + amount);
        }

        private void SetCurrent(float amount)
        {
            _current = Mathf.Clamp(amount, _min, _max);
        }
    }
}