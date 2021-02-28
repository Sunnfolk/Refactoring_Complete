using UnityEngine;

namespace Refactored.Animation
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void UpdateAnimation(Vector2 input)
        {
            if (input != Vector2.zero)
            {
                _animator.SetFloat(Horizontal, input.x);
                _animator.SetFloat(Vertical, input.y);
                _animator.SetBool(IsWalking, true);
            }
            else { _animator.SetBool(IsWalking, false); }

            if (input.x != 0f)
            {
                // Flips the Object - useful for shooting
                // transform.localScale = new Vector2(input.x, 1f);

                // Flips just the sprite
                _spriteRenderer.flipX = input.x < 0;
            }
        }
    }
}