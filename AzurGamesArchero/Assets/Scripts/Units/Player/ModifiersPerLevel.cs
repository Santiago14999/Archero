using UnityEngine;
using ArcheroLike.Projectiles.PlayerArrows;
using ArcheroLike.UI;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(PlayerExperience))]
    public class ModifiersPerLevel : MonoBehaviour
    {
        PlayerExperience _exp;
        void Awake()
        {
            _exp = GetComponent<PlayerExperience>();
            _exp.PlayerLeveledUp += OnPlayerLeveledUp;
        }

        void OnPlayerLeveledUp()
        {
            if (_exp.Level == 2)
            {
                AddModifier("LightningModifier");
                NotificationController.Instance.ShowMessage("You've got Lightning Modifier!", 1f);
            }
            if (_exp.Level == 3)
            {
                AddModifier("VampirismModifier");
                NotificationController.Instance.ShowMessage("You've got Vampirism Modifier!", 1f);
            }
        }

        void AddModifier(string name)
        {
            IArrowModifier modifier = Resources.Load("ArrowModifiers/" + name) as IArrowModifier;
            ArrowController.Instance.AddModifier(modifier);
        }
    }
}