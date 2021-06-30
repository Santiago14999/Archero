using UnityEngine;
using ArcheroLike.Units.Enemies;

namespace ArcheroLike.Units.Player
{
    public class ElectricityModifier : MonoBehaviour, IArrowModifier
    {
        [SerializeField] float _electricityDamage = 10f;
        [SerializeField] int _chainCount = 3;
        [SerializeField] float _chainDamageReduction = .35f;
        [SerializeField] float _maxChainRange = 5f;

        public void ModifierAction(AbstractEnemy enemy)
        {
            var enemiesController = EnemiesController.Instance;
            AbstractEnemy currentEnemy = enemy;
            for (int i = 0; i < _chainCount; i++)
            {
                if (!enemy.IsAlive)
                    return;

                currentEnemy.TakeDamage(_electricityDamage);
                _electricityDamage *= _chainDamageReduction;
                AbstractEnemy closestEnemy = enemiesController.GetClosestEnemy(currentEnemy);
                if (Vector3.Distance(closestEnemy.transform.position, currentEnemy.transform.position) > _maxChainRange)
                    return;

                currentEnemy = closestEnemy;
            }
        }
    }
}