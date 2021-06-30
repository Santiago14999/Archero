using System;
using UnityEngine;

namespace ArcheroLike.Units
{
    public class Health : MonoBehaviour
    {
        public event Action HealthChanged;

        [SerializeField] float _maxHealth = 100f;
        float _currentHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                HealthChanged?.Invoke();
            }
        }
    }
}
