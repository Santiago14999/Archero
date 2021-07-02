using UnityEngine;
using UnityEngine.UI;

public class ExperienceUI : MonoBehaviour
{
    [SerializeField] Image _expBar;
    [SerializeField] TMPro.TMP_Text _expText;
    [SerializeField] TMPro.TMP_Text _levelText;

    public void UpdateUI(int level, int currentExp, int maxExp)
    {
        _expBar.fillAmount = currentExp / (float)maxExp;
        _expText.text = $"{currentExp}/{maxExp}";
        _levelText.text = $"{level} LVL";
    }
}
