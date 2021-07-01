using System;
using UnityEngine;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(Health))]
    public class PlayerHealth : MonoBehaviour
    {
        public event Action PlayerDied;

        Health _health;
        bool _isAlive = true;

        public float Health
        {
            get => _health.CurrentHealth;
            set
            {
                if (!_isAlive)
                    return;

                _health.CurrentHealth = value;
                if (_health.CurrentHealth <= 0)
                    Die();
            }
        }

        public float MaxHealth
        {
            get => _health.MaxHealth;
            set => _health.MaxHealth = value;
        }

        void Start()
        {
            _health = GetComponent<Health>();
            _health.CurrentHealth = _health.MaxHealth;
        }

        void Die()
        {
            _isAlive = false;
            PlayerDied?.Invoke();
        }
    }
}
