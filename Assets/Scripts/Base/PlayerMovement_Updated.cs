using UnityEngine;

namespace Base
{
    public class PlayerMovement_Updated : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private Vector2 _moveVector;
        private InputActions _input;
        private void Awake() { _input = new InputActions(); }
        private void OnEnable() { _input.Enable(); }
        private void OnDisable() { _input.Disable(); }

        private Rigidbody2D _rigidbody2D;
        
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        // Start is called before the first frame update
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.flipX = false;
        }


        // Update is called once per frame
        private void Update()
        {
            _moveVector = _input.Player.Move.ReadValue<Vector2>();
            // If we are moving in any direction
            if (_moveVector != Vector2.zero)
            {
                // set our Aimation Variables("Parametres") to be the following values.
                _animator.SetFloat("Horizontal", _moveVector.x);
                _animator.SetFloat("Vertical", _moveVector.y);
                _animator.SetBool("isWalking", true);
            }
            else { _animator.SetBool("isWalking", false); }

            // If we are moving
            if (_moveVector.x != 0f)
            {
                // Flip the character around / the sprite around
                // transform.localScale = new Vector3(_xMove, 1f, 1f);
                _spriteRenderer.flipX = (_moveVector.x < 0) ? true : false;
            }
        }

        public void FixedUpdate()
        {
            /*
            // If the Magnitude of the two movement vectors are above 1
            if (_moveVector.magnitude > 1)
            {
                // Remove additional Diagonal speed by normalizing the movement vector
                //(Setting the magnitude back to 1)
                _moveVector = _moveVector.normalized;
            }
            */
            
            // Set out velocity to be equal to the _movevector multiplied with our movement speed;
            _rigidbody2D.velocity = _moveVector * _speed;
        }
    }
}