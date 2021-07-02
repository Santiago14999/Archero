using System;
using UnityEngine;

namespace ArcheroLike.Units.Enemies
{
    [RequireComponent(typeof(Health))]
    public abstract class AbstractEnemy : MonoBehaviour
    {
        [SerializeField] protected float _attackCooldown;
        [SerializeField] protected float _attackDamage;

        protected bool _isAlive;
        protected Health _health;
        protected float _lastAttackTime;

        public static event Action<AbstractEnemy> EnemyDied;
        public event Action EnemyDamaged;

        public float AttackCooldown => _attackCooldown;
        public float AttackDamage => _attackDamage;
        public bool IsAlive => _isAlive;
        public Health Health => _health;

        protected void Start()
        {
            _isAlive = true;
            _health = GetComponent<Health>();
            _health.CurrentHealth = _health.MaxHealth;
            _health.HealthChanged += OnHealthChanged;
        }

        protected void OnHealthChanged()
        {
            if (_isAlive)
            {
                if (_health.CurrentHealth <= 0f)
                    Die();
                else
                    EnemyDamaged?.Invoke();
            }
        }

        protected virtual void Die()
        {
            _isAlive = false;
            EnemyDied?.Invoke(this);
        }
    }
}
