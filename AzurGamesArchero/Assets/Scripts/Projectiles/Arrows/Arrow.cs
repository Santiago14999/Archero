using UnityEngine;
using ArcheroLike.Units.Enemies;

namespace ArcheroLike.Projectiles.PlayerArrows
{
    [RequireComponent(typeof(Collider))]
    public class Arrow : AbstractProjectile
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

        protected override void OnHit(Collider collision)
        {
            if (collision.gameObject.TryGetComponent<AbstractEnemy>(out var enemy))
            {
                OnHitEnemy(enemy);
            }
            Destroy(gameObject);
        }

        void OnHitEnemy(AbstractEnemy enemy)
        {
            ArrowController arrowController = ArrowController.Instance;
            enemy.Health.CurrentHealth -= Damage;
            arrowController.DealtDamage(Damage);
            HitEnemy = enemy;
            arrowController.ArrowModifiers.ForEach(x => x.ModifierAction(this));
        }
    }
}