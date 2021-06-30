using UnityEngine;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(Collider))]
    public class Arrow : MonoBehaviour
    {
        float _speed;

        public void Init(float speed)
        {
            _speed = speed;
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

        void OnHitEnemy(Enemies.AbstractEnemy enemy)
        {
            ArrowController arrowController = ArrowController.Instance;
            enemy.TakeDamage(arrowController.GetArrowDamage());
            var modifiers = arrowController.ArrowModifiers;
            foreach (var modifier in modifiers)
                modifier.ModifierAction(enemy);
        }
    }
}