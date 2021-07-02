using UnityEngine;
using ArcheroLike.UI;
using System;

namespace ArcheroLike.Units.Enemies
{
    public class EnemyGoblin : AbstractEnemy
    {
        [SerializeField] Projectiles.GoblinRockProjectile _rock;
        [SerializeField] Transform _rockSpawnPoint;

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

        protected override void Attack()
        {
            var player = FindObjectOfType<Player.PlayerHealth>();
            transform.LookAt(player.transform);
            var rock = Instantiate(_rock, _rockSpawnPoint.position, Quaternion.identity);
            rock.Init(_health, _rockSpawnPoint.position, player.transform.position, _attackDamage);
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