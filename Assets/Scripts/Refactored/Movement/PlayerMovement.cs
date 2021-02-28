using UnityEngine;

namespace Refactored.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private Rigidbody2D _rigidbody2D;

        private void Start() => _rigidbody2D = GetComponent<Rigidbody2D>();
        public void Move(Vector2 input) => _rigidbody2D.velocity = input.normalized * speed;
        
    }
}
