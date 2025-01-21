using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerBody;
    [SerializeField] private float _moveSpeed = 1f;
    private Vector2 _moveAxis;

    private void FixedUpdate()
    {
        if (_playerBody != null)
        {
            _playerBody.velocity += _moveAxis.normalized * _moveSpeed * Time.deltaTime;
            _playerBody.velocity = new(Mathf.Clamp(_playerBody.velocity.x, -5, 5), _playerBody.velocity.y);
        }
    }

    public void OnMove(InputAction.CallbackContext callback)
    {
        _moveAxis = callback.ReadValue<Vector2>();
    }
}
