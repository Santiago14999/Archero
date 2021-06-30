using System;
using UnityEngine;

namespace ArcheroLike.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public float MaxSpeed = 15f;

        public event Action<bool> MovingStateChanged;

        FloatingJoystick _joystick;
        CharacterController _characterController;
        bool _isMoving = false;

        void Awake()
        {
            _joystick = FindObjectOfType<FloatingJoystick>();
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            HandleMovement();
        }

        void HandleMovement()
        {
            Vector3 input = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
            _characterController.Move(input * Time.deltaTime * MaxSpeed);
            transform.LookAt(transform.position + input);
            UpdateMovingState(input);
        }

        void UpdateMovingState(Vector3 input)
        {
            bool isMoving = input.sqrMagnitude != 0;
            if (isMoving != _isMoving)
            {
                _isMoving = isMoving;
                MovingStateChanged?.Invoke(isMoving);
            }
        }
    }
}
