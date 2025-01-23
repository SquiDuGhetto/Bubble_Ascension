using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _maxMoveSpeed = 5;
    private Vector2 _moveAxis;
    private float _patinsMove = 1;

    public bool CanMove { get { return enabled; } set { enabled = value; } }

    public void OnInventoryChange(PlayerInventory inventory)
    {
        if (inventory.HasItem("Patins"))
        {
            _patinsMove = 1.5f;
            return;
        }
        _patinsMove = 1f;
    }

    private void FixedUpdate()
    {
        if (_playerBody != null)
        {
            Vector2 direction = _moveAxis.normalized;
            direction.y = 0;

            _playerBody.velocity += direction * _moveSpeed * Time.fixedDeltaTime;
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
