using ArcheroLike.Units;
using UnityEngine;

namespace ArcheroLike.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerCombat : AbstractEnemy
    {
        PlayerMovement _playerMovement;
        bool _isMoving = false;

        void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.MovingStateChanged += UpdateMovingState;
        }

        void UpdateMovingState(bool moving)
        {

        }

        void Update()
        {
            HandleShooting();
        }

        void HandleShooting()
        {

        }

    }
}
