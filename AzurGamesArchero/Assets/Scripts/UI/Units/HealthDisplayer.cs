using System;
using UnityEngine;
using ArcheroLike.Units;

namespace ArcheroLike.UI
{
    [RequireComponent(typeof(Health))]
    public class HealthDisplayer : MonoBehaviour
    {
        public static event Action<bool, HealthDisplayer> HealthOwnerStateChanged;

        [SerializeField] HealthUI _healthUIPrefab;

        Health _health;

        public Health Health
        {
            get
            {
                if (_health == null)
                    _health = GetComponent<Health>();

                return _health;
            }
        }
        public HealthUI HealthUIPrefab => _healthUIPrefab;
        public float HealthPercentage => Mathf.Clamp01(_health.CurrentHealth / _health.MaxHealth);

        void OnEnable()
        {
            HealthOwnerStateChanged?.Invoke(true, this);
        }

        void OnDisable()
        {
            HealthOwnerStateChanged?.Invoke(false, this);
        }
    }
}