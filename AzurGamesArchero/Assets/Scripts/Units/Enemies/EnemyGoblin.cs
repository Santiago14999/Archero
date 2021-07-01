using UnityEngine;
using ArcheroLike.UI;
using System;

namespace ArcheroLike.Units.Enemies
{
    public class EnemyGoblin : AbstractEnemy
    {
        public event Action EnemyAttacked;

        void Awake()
        {
            SetRagdoll(false);
        }

        void Update()
        {
            if (!IsAlive)
                return;

            HandleAttack();
        }

        void HandleAttack()
        {
            if (_lastAttackTime + _attackCooldown <= Time.time)
            {
                _lastAttackTime = Time.time;
                EnemyAttacked?.Invoke();
                Attack();
            }
        }

        void Attack()
        {
            var player = FindObjectOfType<Player.PlayerHealth>();
            transform.LookAt(player.transform);
            
        }

        protected override void Die()
        {
            base.Die();
            GetComponent<Animator>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<HealthDisplayer>().enabled = false;
            SetRagdoll(true);
        }

        void SetRagdoll(bool state)
        {
            foreach (var rb in GetComponentsInChildren<Rigidbody>())
                rb.isKinematic = !state;
        }
    }
}