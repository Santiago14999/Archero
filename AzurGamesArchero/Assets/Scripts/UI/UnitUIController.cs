using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ArcheroLike.Units;

namespace ArcheroLike.UI
{
    public class UnitUIController : MonoBehaviour
    {
        [SerializeField] Transform _unitsUIParent;
        Dictionary<AbstractEnemy, UnitUI> _unitsUI = new Dictionary<AbstractEnemy, UnitUI>();

        const string UNIT_UI_PREFABS_PATH = "Prefabs/UnitUI";

        static UnitUIController _instance;
        public static UnitUIController Instance
        {
            private set => _instance = value;
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<UnitUIController>();

                return _instance;
            }
        }
        public static RectTransform MainCanvas;
        public static Camera MainCamera;

        void Awake()
        {
            MainCanvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
            MainCamera = FindObjectOfType<Camera>();
            AbstractEnemy.EnemyStateChanged += OnUnitStateChanged;
            ProcessEarlyCreatedUnits();
        }

        private void OnDestroy()
        {
            AbstractEnemy.EnemyStateChanged -= OnUnitStateChanged;
        }

        void ProcessEarlyCreatedUnits()
        {
            var units = FindObjectsOfType<AbstractEnemy>();
            foreach (var unit in units)
            {
                AddUnitUI(unit);
            }
        }

        void OnUnitStateChanged(bool enabled, AbstractEnemy unit)
        {
            if (enabled)
                AddUnitUI(unit);
            else
                RemoveUnitUI(unit);
        }

        void AddUnitUI(AbstractEnemy unit)
        {
            if (!_unitsUI.ContainsKey(unit))
            {
                var unitUI = Instantiate(Resources.Load<UnitUI>(UNIT_UI_PREFABS_PATH), _unitsUIParent);
                _unitsUI.Add(unit, unitUI);
                unitUI.Init(unit);
            }
        }

        void RemoveUnitUI(AbstractEnemy unit)
        {
            if (_unitsUI.ContainsKey(unit))
            {
                Destroy(_unitsUI[unit].gameObject);
                _unitsUI.Remove(unit);
            }
        }
    }
}
