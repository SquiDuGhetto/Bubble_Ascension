using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _moveSpeed = 1f;
    private Vector2 _moveAxis;

    public bool CanMove { get { return enabled; } set { enabled = value; } }

    private void FixedUpdate()
    {
        if (_playerBody != null)
        {
            Vector2 direction = _moveAxis.normalized;
            direction.y = 0;

            // if (_controller.IsGrounded() == false)
            // {
            //     direction /= 2;
            // }

            _playerBody.velocity += direction * _moveSpeed * Time.deltaTime;
            _playerBody.velocity = new(Mathf.Clamp(_playerBody.velocity.x, -3, 3), _playerBody.velocity.y);
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
