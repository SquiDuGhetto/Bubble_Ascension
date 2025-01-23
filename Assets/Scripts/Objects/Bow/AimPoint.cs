using UnityEngine;
using UnityEngine.InputSystem;

public class AimPoint : MonoBehaviour
{
    private Vector3 _aimDirection;

    public bool CanRotate { get; set; }

    private void Update()
    {
        if (CanRotate == false)
            return;

        Vector3 moveVector = (Vector3.up * _aimDirection.x + Vector3.left * _aimDirection.y);
        if (_aimDirection.x != 0 && _aimDirection.y != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
    }

    public void OnAim(InputAction.CallbackContext callback)
    {
        _aimDirection = callback.ReadValue<Vector2>();
    }
}
