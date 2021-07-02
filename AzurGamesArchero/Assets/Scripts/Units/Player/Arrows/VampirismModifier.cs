using ArcheroLike.Units.Enemies;
using UnityEngine;

namespace ArcheroLike.Units.Player
{
    [CreateAssetMenu(fileName = "VampirismModifier", menuName = "ArrowModifiers/VampirismModifier")]
    public class VampirismModifier : ScriptableObject, IArrowModifier
    {
        [SerializeField] float _vampirismPercent = .23f;
        public void ModifierAction(Arrow arrow)
        {
            var playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.Health.CurrentHealth += arrow.Damage * _vampirismPercent;
        }
    }
}