using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ArcheroLike.Units;

namespace ArcheroLike.UI
{
    public class HealthUIController : MonoBehaviour
    {
        [SerializeField] Transform _unitsHealthUIParent;
        Dictionary<HealthDisplayer, HealthUI> _unitsHealthUI = new Dictionary<HealthDisplayer, HealthUI>();

        static HealthUIController _instance;
        public static HealthUIController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<HealthUIController>();

                return _instance;
            }
        }
        public static RectTransform MainCanvas;
        public static Camera MainCamera;

        void Awake()
        {
            MainCanvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
            MainCamera = FindObjectOfType<Camera>();
            HealthDisplayer.HealthOwnerStateChanged += OnUnitStateChanged;
            ProcessEarlyCreatedUnits();
        }

        private void OnDestroy()
        {
            HealthDisplayer.HealthOwnerStateChanged -= OnUnitStateChanged;
        }

        void ProcessEarlyCreatedUnits()
        {
            var units = FindObjectsOfType<HealthDisplayer>();
            foreach (var unit in units)
            {
                AddUnitHealthUI(unit);
            }
        }

        void OnUnitStateChanged(bool enabled, HealthDisplayer unit)
        {
            if (enabled)
                AddUnitHealthUI(unit);
            else
                RemoveUnitHealthUI(unit);
        }

        void AddUnitHealthUI(HealthDisplayer unit)
        {
            if (!_unitsHealthUI.ContainsKey(unit))
            {
                var unitUI = Instantiate(unit.HealthUIPrefab, _unitsHealthUIParent);
                _unitsHealthUI.Add(unit, unitUI);
                unitUI.Init(unit);
            }
        }

        void RemoveUnitHealthUI(HealthDisplayer unit)
        {
            if (_unitsHealthUI.ContainsKey(unit))
            {
                Destroy(_unitsHealthUI[unit].gameObject);
                _unitsHealthUI.Remove(unit);
            }
        }
    }
}
