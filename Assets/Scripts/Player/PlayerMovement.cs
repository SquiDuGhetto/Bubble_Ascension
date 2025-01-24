using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _maxMoveSpeed = 5;
    [SerializeField] private Transform _renderer;
    [SerializeField] private Playersprite _sprite;
    private Vector2 _moveAxis;

    public bool CanMove { get { return enabled; } set { enabled = value; } }

    private void FixedUpdate()
    {
        if (_playerBody != null)
        {
            Vector2 direction = _moveAxis.normalized;
            direction.y = 0;

            if (direction.x < 0f)
                _renderer.localScale = new Vector2(-1f, _renderer.localScale.y);
            else
                _renderer.localScale = new Vector2(1f, _renderer.localScale.y);

            if (_controller.IsGrounded())
            {
                _sprite.CharAnimator.SetBool("IsJumping", false);

                if (_moveAxis.x != 0)
                    _sprite.CharAnimator.SetBool("IsRunning", true);
                else
                    _sprite.CharAnimator.SetBool("IsRunning", false);

            }
            else
            {
                _sprite.CharAnimator.SetBool("IsRunning", false);
                _sprite.CharAnimator.SetBool("IsJumping", true);
            }

            _playerBody.velocity += _moveSpeed * Time.fixedDeltaTime * direction;
            _playerBody.velocity = new(Mathf.Clamp(_playerBody.velocity.x, -_maxMoveSpeed, _maxMoveSpeed), _playerBody.velocity.y);
        }
    }

    public void OnMove(InputAction.CallbackContext callback)
    {
        _moveAxis = callback.ReadValue<Vector2>();
    }

    public Vector2 GetMoveAxis()
    {
        return _moveAxis;
    }
}
