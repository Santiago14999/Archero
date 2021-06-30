using System;
using UnityEngine;

namespace ArcheroLike.Units
{
    [RequireComponent(typeof(Health))]
    public abstract class AbstractEnemy : MonoBehaviour
    {
        [SerializeField] protected float _attackSpeed;
        [SerializeField] protected float _attackDamage;

        protected Health _health;
        protected float _lastAttackTime;

        public event Action EnemyDied;

        public float AttackSpeed => _attackSpeed;
        public float AttackDamage => _attackDamage;

        protected void Start()
        {
            _health = GetComponent<Health>();
            _health.CurrentHealth = _health.MaxHealth;
        }

        protected void TakeDamage(float damage)
        {
            _health.CurrentHealth -= damage;
            if (_health.CurrentHealth <= 0)
                Die();
        }

        protected virtual void Die()
        {
            EnemyDied?.Invoke();
        }
    }
}
