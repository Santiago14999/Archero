using UnityEngine;
using ArcheroLike.Units;

namespace ArcheroLike.Projectiles
{
    public class GoblinRockProjectile : AbstractProjectile
    {
        [SerializeField] float _speed = 10f;
        [SerializeField] float _rotationSpeed = 10f;

        Vector3 _from;
        Vector3 _to;
        float _damage;
        float _initTime;
        float _flightTime;
        float _projectileHeight;
        Health _owner;

        public void Init(Health owner, Vector3 from, Vector3 to, float damage)
        {
            _owner = owner;
            _damage = damage;
            _from = from;
            _to = to;
            _initTime = Time.time;
            _flightTime = Vector3.Distance(from, to) / Mathf.Max(1f, _speed);
            _projectileHeight = Vector3.Distance(from, to) * .5f;
        }

        void Update()
        {
            Move();
            Rotate();
        }

        void Move()
        {
            float normalizedTime = (Time.time - _initTime) / _flightTime;
            if (normalizedTime >= 1f)
                DestroyProjectile();

            transform.position = Vector3.Lerp(_from, _to, normalizedTime) + Vector3.up * Mathf.Sin(normalizedTime * Mathf.PI) * _projectileHeight;
        }

        void Rotate()
        {
            transform.Rotate(Vector3.one * _rotationSpeed * Time.deltaTime);
        }

        protected override void OnHit(Collider collision)
        {
            if (collision.gameObject.TryGetComponent<Health>(out var health))
            {
                if (health == _owner)
                    return;

                health.CurrentHealth -= _damage;
            }
            DestroyProjectile();
        }

        void DestroyProjectile()
        {
            Destroy(gameObject);
        }
    }
}