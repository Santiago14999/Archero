using ArcheroLike.Units;
using UnityEngine;

namespace ArcheroLike.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(Health))]
    public class PlayerCombat : MonoBehaviour
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
