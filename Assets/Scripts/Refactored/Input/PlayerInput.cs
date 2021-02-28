using UnityEngine;
using UnityEngine.InputSystem;

namespace Refactored.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 MoveVector { get; private set; }
        private void OnMove(InputValue value) => MoveVector = value.Get<Vector2>();
    }
}