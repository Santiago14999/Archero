using System;
using UnityEngine;

namespace ArcheroLike.Units
{
    public class Health : MonoBehaviour
    {
        public event Action HealthChanged;

        [SerializeField] float _maxHealth = 100f;
        float _currentHealth;

        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
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
