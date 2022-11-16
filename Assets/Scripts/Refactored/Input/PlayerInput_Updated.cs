using UnityEngine;

namespace Refactored.Input
{
    public class PlayerInput_Updated : MonoBehaviour
    {
        public Vector2 MoveVector { get; private set; }
        
        private InputActions _input;
		private void Awake() { _input = new InputActions(); }
		private void OnEnable() { _input.Enable(); }
		private void OnDisable() { _input.Disable(); }

		private void Update()
		{
			MoveVector = _input.Player.Move.ReadValue<Vector2>();
		}
    }
}