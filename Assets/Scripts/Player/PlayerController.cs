using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 0.6f, _groundMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
