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
            _playerExp.PlayerGainedExperience += OnPlayerGainedExperience;
            OnPlayerGainedExperience();
        }

        void OnPlayerGainedExperience()
        {
            _expUI.UpdateExpUI(_playerExp.Level, _playerExp.Experience, _playerExp.NextLevelExperience);
        }
    }
}
