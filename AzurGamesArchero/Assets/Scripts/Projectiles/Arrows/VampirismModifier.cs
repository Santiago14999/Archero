using ArcheroLike.Units.Player;
using UnityEngine;

namespace ArcheroLike.Projectiles.PlayerArrows
{
    [CreateAssetMenu(fileName = "VampirismModifier", menuName = "ArrowModifiers/VampirismModifier")]
    public class VampirismModifier : ScriptableObject, IArrowModifier
    {
        [SerializeField] float _vampirismPercent = .23f;

        PlayerHealth _playerHealth;
        bool _isActive = false;

        public void ModifierAction(Arrow arrow)
        {
            if (_isActive)
                return;

            _isActive = true;
            _playerHealth = FindObjectOfType<PlayerHealth>();
            ArrowController.Instance.PlayerDealtDamage += Heal;
        }

        void Heal(float value)
        {
            _playerHealth.Health.CurrentHealth += value * _vampirismPercent;
        }
    }
}