using System;
using UnityEngine;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(Health))]
    public class PlayerHealth : MonoBehaviour
    {
        public event Action PlayerDied;

        Health _health;
        bool _isAlive;

        public Health Health => _health;

        void Start()
        {
            _isAlive = true;
            _health = GetComponent<Health>();
            _health.CurrentHealth = _health.MaxHealth;
            _health.HealthChanged += OnHealthChanged;
        }

        void OnHealthChanged()
        {
            if (_isAlive && _health.CurrentHealth <= 0f)
                Die();
        }

        void Die()
        {
            _isAlive = false;
            PlayerDied?.Invoke();
        }
    }
}
