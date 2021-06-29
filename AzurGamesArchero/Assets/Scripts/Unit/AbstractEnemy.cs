using System;
using UnityEngine;

namespace ArcheroLike.Units
{
    public abstract class AbstractEnemy : MonoBehaviour
    {
        public static event Action<bool, AbstractEnemy> EnemyStateChanged;

        [SerializeField] protected float _maxHealth;
        [SerializeField] protected float _attackSpeed;
        [SerializeField] protected float _attackDamage;

        protected float _currentHealth;
        protected float _lastAttackTime;

        public event Action EnemyHealthChanged;
        public event Action EnemyDied;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = value;
                EnemyHealthChanged?.Invoke();
                if (_currentHealth <= 0f)
                    Die();
            }
        }
        public float AttackSpeed => _attackSpeed;
        public float AttackDamage => _attackDamage;

        protected void OnEnable()
        {
            EnemyStateChanged?.Invoke(true, this);
        }

        protected void OnDisable()
        {
            EnemyStateChanged?.Invoke(false, this);
        }

        protected void Start()
        {
            _currentHealth = MaxHealth;
        }

        protected virtual void Die()
        {
            _currentHealth = 0;
            EnemyDied?.Invoke();
        }
    }
}
