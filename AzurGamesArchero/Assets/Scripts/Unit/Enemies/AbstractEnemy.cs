using System;
using UnityEngine;

namespace ArcheroLike.Units.Enemies
{
    [RequireComponent(typeof(Health))]
    public abstract class AbstractEnemy : MonoBehaviour
    {
        [SerializeField] protected float _attackSpeed;
        [SerializeField] protected float _attackDamage;

        protected Health _health;
        protected float _lastAttackTime;
        protected bool _isAlive = true;

        public static event Action<AbstractEnemy> EnemyDied;

        public float AttackSpeed => _attackSpeed;
        public float AttackDamage => _attackDamage;
        public bool IsAlive => _isAlive;

        protected void Start()
        {
            _health = GetComponent<Health>();
            _health.CurrentHealth = _health.MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (!_isAlive)
                return;

            _health.CurrentHealth -= damage;
            if (_health.CurrentHealth <= 0)
                Die();
        }

        protected virtual void Die()
        {
            _isAlive = false;
            EnemyDied?.Invoke(this);
        }
    }
}
