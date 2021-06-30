using UnityEngine;
using ArcheroLike.Units.Enemies;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(Health))]
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] float _attackCooldown = 1f;
        [SerializeField] Transform _arrowSpawnPoint;

        AbstractEnemy _currentTarget;
        PlayerMovement _playerMovement;
        bool _isMoving = false;
        float _lastShotTime;

        void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.MovingStateChanged += UpdateMovingState;
            AbstractEnemy.EnemyDied += OnEnemyDied;
        }

        void OnDestroy()
        {
            AbstractEnemy.EnemyDied -= OnEnemyDied;
        }

        void OnEnemyDied(AbstractEnemy enemy)
        {
            if (_currentTarget != null && _currentTarget == enemy)
                _currentTarget = null;
        }

        void UpdateMovingState(bool moving)
        {
            _isMoving = moving;
            if (!moving)
            {
                _lastShotTime = Time.time;
                _currentTarget = EnemiesController.Instance.GetClosestEnemy(transform.position);
                if (_currentTarget != null)
                    _playerMovement.FaceTarget(_currentTarget.transform);
            }
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
            ArrowController.Instance.SpawnArrow(_arrowSpawnPoint.position, _arrowSpawnPoint.rotation);
        }

    }
}
