using UnityEngine;
using ArcheroLike.Units.Player;

namespace ArcheroLike.UI
{
    public class GameUIController : MonoBehaviour
    {
        ExperienceUI _expUI;
        PlayerExperience _playerExp;

        void Start()
        {
            _expUI = FindObjectOfType<ExperienceUI>();
            _playerExp = FindObjectOfType<PlayerExperience>();
            _playerExp.PlayerGainExperience += OnPlayerGainExperience;
            OnPlayerGainExperience();
        }

        void OnPlayerGainExperience()
        {
            _expUI.UpdateUI(_playerExp.Level, _playerExp.Experience, _playerExp.NextLevelExperience);
        }
    }
}
