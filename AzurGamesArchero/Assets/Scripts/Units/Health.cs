using System;
using UnityEngine;

namespace ArcheroLike.Units
{
    public class Health : MonoBehaviour
    {
        public event Action HealthChanged;

        [SerializeField] protected float _maxHealth = 100f;
        protected float _currentHealth;

        public float MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                HealthChanged?.Invoke();
            }
        }

        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
                HealthChanged?.Invoke();
            }
        }
    }
}
