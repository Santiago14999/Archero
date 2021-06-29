using UnityEngine;

namespace ArcheroLike.Units
{
    public class EnemyGoblin : AbstractEnemy
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
                CurrentHealth -= 10f;
        }
        protected override void Die()
        {
            base.Die();
            Destroy(gameObject);
        }
    }
}