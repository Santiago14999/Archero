using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ArcheroLike.Units.Enemies;

namespace ArcheroLike.Units.Player
{
    [CreateAssetMenu(fileName = "ElectricityModifier", menuName = "ArrowModifiers/ElectricityModifier")]
    public class ElectricityModifier : ScriptableObject, IArrowModifier
    {
        [SerializeField] float _electricityDamage = 20f;
        [SerializeField] int _chainCount = 3;
        [SerializeField] float _chainDamageReduction = .35f;
        [SerializeField] float _maxChainRange = 100f;
        [SerializeField] float _procChance = .2f;

        public void ModifierAction(Arrow arrow)
        {
            if (Random.Range(0f, 1f) > _procChance)
                return;

            AbstractEnemy currentEnemy = arrow.HitEnemy;
            float currentDamage = _electricityDamage;

            List<AbstractEnemy> affectedEnemies = new List<AbstractEnemy>();

            for (int i = 0; i < _chainCount; i++)
            {
                currentEnemy.Health.CurrentHealth -= currentDamage;
                affectedEnemies.Add(currentEnemy);

                currentDamage *= _chainDamageReduction;

                AbstractEnemy closestEnemy = GetNextEnemy(currentEnemy, affectedEnemies);
                if (closestEnemy == null || Vector3.Distance(closestEnemy.transform.position, currentEnemy.transform.position) > _maxChainRange)
                    return;

                currentEnemy = closestEnemy;
            }
        }

        AbstractEnemy GetNextEnemy(AbstractEnemy from, List<AbstractEnemy> affectedEnemies)
        {
            var enemies = EnemiesController.Instance.Enemies;
            return enemies
                .Except(affectedEnemies)
                .OrderBy(x => Vector3.SqrMagnitude(x.transform.position - from.transform.position))
                .FirstOrDefault();
        }
    }
}