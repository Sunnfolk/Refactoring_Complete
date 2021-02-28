using Refactored.Animation;
using Refactored.Input;
using Refactored.Movement;
using UnityEngine;

namespace Refactored
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput _input;
        private PlayerAnimation _animation;
        private PlayerMovement _movement;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _animation = GetComponent<PlayerAnimation>();
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update() => _animation.UpdateAnimation(_input.MoveVector);
        
        private void FixedUpdate() => _movement.Move(_input.MoveVector);

    }
}
