using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _jumpForce = 5f;

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.6f, _mask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    public void OnJump(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            if (IsGrounded() == false)
                return;
            _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.6f);
    }
}
