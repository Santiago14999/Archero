using ArcheroLike.Units.Enemies;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArcheroLike.Projectiles.PlayerArrows
{
    public class LightningEntity : MonoBehaviour
    {
        LightningModifier _settings;
        float _lastHitTime;
        float _currentDamage;
        int _currentChain;
        AbstractEnemy _target;
        Vector3 _prevEnemyPos;
        Vector3 _nextEnemyPos;

        List<AbstractEnemy> _affectedEnemies;
        ArrowController _arrowController;

        public void Init(LightningModifier settings, AbstractEnemy firstEnemy)
        {
            _arrowController = ArrowController.Instance;
            _settings = settings;
            _currentDamage = settings.LightningFirstDamage;
            _currentChain = 0;
            _affectedEnemies = new List<AbstractEnemy>();
            transform.position = firstEnemy.transform.position;
            _target = firstEnemy;
        }

        void Update()
        {
            HandleChain();
            HandleEntityPosition();
        }

        void HandleEntityPosition()
        {
            float t = Mathf.Clamp01((Time.time - _lastHitTime) / _settings.TransitionTime);
            transform.position = Vector3.Lerp(_prevEnemyPos, _nextEnemyPos, t) + Vector3.up;
        }

        void HandleChain()
        {
            if (_lastHitTime + _settings.TransitionTime <= Time.time)
            {
                HitTargetEnemy();
                _target = TryFindNextEnemy();
                if (_target != null)
                {
                    _nextEnemyPos = _target.transform.position;
                    if (Vector3.Distance(_prevEnemyPos, _nextEnemyPos) <= _settings.MaxChainDistance)
                        return;
                }
                DestroyEntity();
            }
        }

        void HitTargetEnemy()
        {
            _lastHitTime = Time.time;
            _target.Health.CurrentHealth -= _currentDamage;
            _arrowController.DealtDamage(_currentDamage);
            _currentDamage *= _settings.ChainDamageReduction;
            _affectedEnemies.Add(_target);
            _prevEnemyPos = _target.transform.position;
            _currentChain++;
            if (_currentChain == _settings.ChainCount)
                DestroyEntity();
        }

        AbstractEnemy TryFindNextEnemy()
        {
            var enemies = EnemiesController.Instance.Enemies;
            return enemies
                .Except(_affectedEnemies)
                .OrderBy(x => Vector3.SqrMagnitude(x.transform.position - _prevEnemyPos))
                .FirstOrDefault();
        }

        void DestroyEntity()
        {
            Destroy(gameObject);
        }
    }
}