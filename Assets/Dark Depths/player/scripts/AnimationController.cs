using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private float _movementDirection;
    private bool _isFacingRight = true;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetRunningAnimation();
    }

    private void SetRunningAnimation()
    {
        Vector3 velocity = _rigidbody2D.velocity;
        
        float currentSpeed = velocity.magnitude;

        bool isRunning = currentSpeed > 0.1f; 
        _animator.SetBool("IsRunning", isRunning);

        if (velocity.x > 0 && !_isFacingRight)
        {
            Rotate();
        }
        else if (velocity.x < 0 && _isFacingRight)
        {
            Rotate();
        }
    }
    
    private void Rotate()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
}
