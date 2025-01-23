using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject _renderer;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _duration = 1;
    private bool _canAttack = false;
    private AimPoint _aimPoint;
     AudioManager audioManager;
    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _aimPoint = GetComponent<AimPoint>();
    }

    public void OnInventoryChange(PlayerInventory inventory)
    {
        if (inventory.HasItem("Sword"))
        {
            _canAttack = true;
            return;
        }
        _canAttack = false;
    }

    public void OnAttack(InputAction.CallbackContext callback)
    {
        if (callback.started && _canAttack == true)
        {
            audioManager.PlaySFX(audioManager.Sword);
            _renderer.SetActive(true);
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        _aimPoint.CanRotate = false;
        _canAttack = false;
        _collider.enabled = true;
        yield return new WaitForSeconds(_duration);
        _canAttack = true;
        _collider.enabled = false;
        _renderer.SetActive(false);
        _aimPoint.CanRotate = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IHitable>(out IHitable hitable))
        {
            hitable.Hit(1);
        }
    }
}
