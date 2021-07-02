using UnityEngine;

namespace ArcheroLike.Units.Enemies
{
    [RequireComponent(typeof(AbstractEnemy), typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        Animator _animator;
        AbstractEnemy _enemy;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemy = GetComponent<AbstractEnemy>();
            _enemy.EnemyAttacked += OnEnemyAttacked;
            _enemy.EnemyDamaged += OnEnemyDamaged;
        }

        void OnEnemyDamaged()
        {
            _animator.SetTrigger("Damaged");
        }

        void OnEnemyAttacked()
        {
            _animator.SetTrigger("Attack");
        }
    }
}
