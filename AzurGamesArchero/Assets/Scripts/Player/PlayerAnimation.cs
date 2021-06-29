using UnityEngine;

namespace ArcheroLike.Player
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
            if (TryGetComponent<PlayerMovement>(out _playerMovement))
            {
                _playerMovement.MovingStateChanged += UpdateMovingState;
            }
            if (TryGetComponent<PlayerCombat>(out _playerCombat))
            {
                
            }
        }

        void UpdateMovingState(bool moving)
        {
            _animator.SetBool("Moving", moving);
        }
    }
}
