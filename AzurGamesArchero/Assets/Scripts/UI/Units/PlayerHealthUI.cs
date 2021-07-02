using UnityEngine;

namespace ArcheroLike.UI
{
    public class PlayerHealthUI : HealthUI
    {
        [SerializeField] TMPro.TMP_Text _healthText;

        protected override void UpdateHealth()
        {
            base.UpdateHealth();
            _healthText.text = $"{_healthDisplayer.Health.CurrentHealth} HP";
        }
    }
}