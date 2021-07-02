using UnityEngine;
using ArcheroLike.Units.Enemies;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(Collider))]
    public class Arrow : MonoBehaviour
    {
        float _speed;

        public AbstractEnemy HitEnemy { get; private set; }
        public float Damage { get; private set; }

        public void Init(float speed, float damage)
        {
            _speed = speed;
            Damage = damage;
        }

        void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Enemies.AbstractEnemy>(out var enemy))
            {
                OnHitEnemy(enemy);
            }
            Destroy(gameObject);
        }

        void OnHitEnemy(AbstractEnemy enemy)
        {
            ArrowController arrowController = ArrowController.Instance;
            enemy.Health.CurrentHealth -= Damage;
            HitEnemy = enemy;
            arrowController.ArrowModifiers.ForEach(x => x.ModifierAction(this));
        }
    }
}