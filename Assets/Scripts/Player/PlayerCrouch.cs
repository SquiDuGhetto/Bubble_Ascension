using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private Vector3 _crouchScale;
    [SerializeField] private UnityEvent<bool> _onCrouchValueChange;
    private bool _isCrouched;

    public bool Crouched
    {
        get
        {
            if (_controller.IsGrounded())
            {
                return _isCrouched;
            }
            return false;
        }
        set
        {
            _isCrouched = value;
            _onCrouchValueChange.Invoke(value);
            if (value == true)
                _movement.CanMove = false;
            else
                _movement.CanMove = true;
        }
    }

    public void OnCrouch(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            Crouched = true;
        }

        if (callback.canceled)
            Crouched = false;

    }
}
