using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _jumpForce = 5f;

    public void OnJump(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            if (_controller.IsGrounded() == false)
                return;

            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
        }

        if (callback.canceled)
        {
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y * 0.25f);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.6f);
    }
}
