using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private PlayerCrouch _crouch;
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _jumpForce = 5f;


    public void OnJump(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            if (_controller.IsGrounded() == false)
                return;
            _crouch.Crouched = false;
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.6f);
    }
}
