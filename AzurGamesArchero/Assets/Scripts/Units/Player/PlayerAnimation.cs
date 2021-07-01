using UnityEngine;

namespace ArcheroLike.Units.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        Animator _animator;
        PlayerMovement _playerMovement;
        PlayerCombat _playerCombat;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            if (TryGetComponent(out _playerMovement))
            {
                _playerMovement.MovingStateChanged += UpdateMovingState;
            }
            if (TryGetComponent(out _playerCombat))
            {
                _playerCombat.PlayerShot += OnPlayerShot;
            }
        }

        void UpdateMovingState(bool moving)
        {
            _animator.SetBool("Moving", moving);
        }
        
        void OnPlayerShot()
        {
            _animator.SetTrigger("Shoot");
        }
    }
}
