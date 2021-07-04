using UnityEngine;
using ArcheroLike.Units.Enemies;

namespace ArcheroLike.Projectiles.PlayerArrows
{
    [CreateAssetMenu(fileName = "LightningModifier", menuName = "ArrowModifiers/LightningModifier")]
    public class LightningModifier : ScriptableObject, IArrowModifier
    {
        [SerializeField] LightningEntity _lightningPrefab;

        public float LightningFirstDamage = 20f;
        public int ChainCount = 3;
        public float ChainDamageReduction = .35f;
        public float MaxChainDistance = 100f;
        public float ProcChance = .2f;
        public float TransitionTime = .1f;

        public void ModifierAction(Arrow arrow)
        {
            if (Random.Range(0f, 1f) > ProcChance)
                return;

            AbstractEnemy enemy = arrow.HitEnemy;
            Instantiate(_lightningPrefab).Init(this, enemy);
        }


    }
}