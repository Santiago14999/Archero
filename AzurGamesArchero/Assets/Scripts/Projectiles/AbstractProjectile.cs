using UnityEngine;

namespace ArcheroLike.Projectiles
{
    public abstract class AbstractProjectile : MonoBehaviour, IIgnoreSelfCollisions
    {
        [SerializeField] Particle _hitEffect;

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IIgnoreSelfCollisions>() != null)
                return;

            Instantiate(_hitEffect, transform.position, Quaternion.identity);
            OnHit(other);
        }

        protected abstract void OnHit(Collider collision);
    }
}