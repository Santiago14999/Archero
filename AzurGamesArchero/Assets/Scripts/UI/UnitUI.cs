using UnityEngine;
using UnityEngine.UI;
using ArcheroLike.Units;

namespace ArcheroLike.UI
{
    public class UnitUI : MonoBehaviour
    {
        [SerializeField] Image _healthBar;
        [SerializeField] float _height;
        AbstractEnemy _unit;
        RectTransform _rectTransform;

        public void Init(AbstractEnemy unit)
        {
            _unit = unit;
            _rectTransform = GetComponent<RectTransform>();
            unit.EnemyHealthChanged += UpdateHealth;
        }

        void UpdateHealth()
        {
            _healthBar.fillAmount = _unit.CurrentHealth / _unit.MaxHealth;
        }

        void Update()
        {
            Camera camera = UnitUIController.MainCamera;
            RectTransform canvas = UnitUIController.MainCanvas;
            Vector2 ViewportPosition = camera.WorldToViewportPoint(_unit.transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * canvas.sizeDelta.x) - (canvas.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f)) + _height);

            _rectTransform.anchoredPosition = WorldObject_ScreenPosition;
        }
    }
}
