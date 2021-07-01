using ArcheroLike.Units.Player;
using UnityEngine;

public class ArrowModifierTester : MonoBehaviour
{
    [SerializeField] string _modifier;

    public void AddModifier()
    {
        IArrowModifier modifier = Resources.Load("ArrowModifiers/" + _modifier) as IArrowModifier;
        if (modifier == null)
            throw new System.Exception($"There is no \"{_modifier}\" modifier");

        ArrowController.Instance.AddModifier(modifier);
    }
}
