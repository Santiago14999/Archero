using UnityEngine;
using UnityEngine.UI;

namespace ArcheroLike.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] protected Image _healthBar;
        [SerializeField] protected float _healthBarHeight;

        protected HealthDisplayer _healthDisplayer;
        protected RectTransform _rectTransform;

        public void Init(HealthDisplayer healthDisplayer)
        {
            _healthDisplayer = healthDisplayer;
            _rectTransform = GetComponent<RectTransform>();
            healthDisplayer.Health.HealthChanged += UpdateHealth;
        }

        protected virtual void UpdateHealth()
        {
            _healthBar.fillAmount = _healthDisplayer.HealthPercentage;
        }

        protected void Update()
        {
            Camera camera = HealthUIController.MainCamera;
            RectTransform canvas = HealthUIController.MainCanvas;
            Vector2 ViewportPosition = camera.WorldToViewportPoint(_healthDisplayer.transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * canvas.sizeDelta.x) - (canvas.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f)) + _healthBarHeight);

            _rectTransform.anchoredPosition = WorldObject_ScreenPosition;
        }
    }
}
