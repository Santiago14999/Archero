using System;
using UnityEngine;

namespace ArcheroLike.Units.Enemies
{
    [RequireComponent(typeof(Health))]
    public abstract class AbstractEnemy : MonoBehaviour
    {
        [SerializeField] protected float _attackCooldown;
        [SerializeField] protected float _attackDamage;

        protected Health _health;
        protected float _lastAttackTime;
        protected bool _isAlive = true;

        public static event Action<AbstractEnemy> EnemyDied;
        public event Action EnemyDamaged;

        public float AttackCooldown => _attackCooldown;
        public float AttackDamage => _attackDamage;
        public bool IsAlive => _isAlive;
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
                else
                    EnemyDamaged?.Invoke();
            }
        }

        protected void Start()
        {
            _health = GetComponent<Health>();
            _health.CurrentHealth = _health.MaxHealth;
        }

        protected virtual void Die()
        {
            _isAlive = false;
            EnemyDied?.Invoke(this);
        }
    }
}
