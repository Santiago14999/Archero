using UnityEngine;
using System.Linq;
using ArcheroLike.Units.Enemies;
using System;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerCombat : MonoBehaviour
    {
        public event Action PlayerShot;

        [SerializeField] float _attackCooldown = 1f;
        [SerializeField] Transform _arrowSpawnPoint;

        AbstractEnemy _currentTarget;
        PlayerMovement _playerMovement;
        float _lastShotTime;
        bool _isMoving = false;

        void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.MovingStateChanged += UpdateMovingState;
            AbstractEnemy.EnemyDied += OnEnemyDied;
        }

        private void Start()
        {
            UpdateMovingState(false);
        }

        void OnDestroy()
        {
            AbstractEnemy.EnemyDied -= OnEnemyDied;
        }

        void OnEnemyDied(AbstractEnemy enemy)
        {
            if (_currentTarget != null && _currentTarget == enemy)
            {
                _currentTarget = null;
                TryFindTarget();
            }
        }

        void UpdateMovingState(bool moving)
        {
            _isMoving = moving;
            if (!moving)
            {
                _lastShotTime = Time.time;
                TryFindTarget();
            }
        }

        void TryFindTarget()
        {
            _currentTarget = TryGetClosestEnemy();
            if (_currentTarget != null)
                _playerMovement.FaceTarget(_currentTarget.transform);
        }

        void Update()
        {
            if (!_isMoving)
                HandleShooting();
        }

        void HandleShooting()
        {
            if (_currentTarget == null)
                return;

            if (_lastShotTime + _attackCooldown <= Time.time)
            {
                _lastShotTime = Time.time;
                Shoot();
            }
        }

        void Shoot()
        {
            PlayerShot?.Invoke();
            ArrowController.Instance.SpawnArrow(_arrowSpawnPoint.position, _arrowSpawnPoint.rotation);
        }

        AbstractEnemy TryGetClosestEnemy()
        {
            var enemies = EnemiesController.Instance.Enemies;
            return enemies.OrderBy(x => Vector3.SqrMagnitude(x.transform.position - transform.position)).FirstOrDefault();
        }
    }
}
