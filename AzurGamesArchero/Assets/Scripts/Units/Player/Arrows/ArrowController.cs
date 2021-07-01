using System.Collections.Generic;
using UnityEngine;

namespace ArcheroLike.Units.Player
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] Arrow _arrow;
        [SerializeField] float _arrowSpeed = 10f;
        [SerializeField] float _stockDamage = 20f;
        [SerializeField] float _stockCritChance = .2f;

        float _damage;
        float _critChance;
        List<IArrowModifier> _modifiers;
        bool _isInit = false;

        static ArrowController _instance;
        public static ArrowController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ArrowController>();

                if (!_instance._isInit)
                    _instance.Init();

                return _instance;
            }
        }
        public List<IArrowModifier> ArrowModifiers => _modifiers;

        void Init()
        {
            _isInit = true;
            _damage = _stockDamage;
            _critChance = _stockCritChance;
            _modifiers = new List<IArrowModifier>();
        }

        public void AddModifier(IArrowModifier modifier)
        {
            _modifiers.Add(modifier);
        }

        public void SpawnArrow(Vector3 position, Quaternion rotation)
        {
            Arrow arrow = Instantiate(_arrow, position, rotation);
            arrow.Init(_arrowSpeed);
        }

        public float GetArrowDamage() => Random.Range(0f, 1f) <= _critChance ? _damage * 2 : _damage;
    }
}