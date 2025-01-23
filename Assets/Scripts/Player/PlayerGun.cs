using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private AimPoint _aim;
    [SerializeField] private string _itemName;
    [SerializeField] private Bullet _arrowPrefab;
    [SerializeField] private Transform _aimPoint;
    [SerializeField] private float _shootCooldown = 1f;
    private bool _canShoot = false;
    AudioManager audioManager;
    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnInventoryChange(PlayerInventory inventory)
    {
        if (inventory.HasItem(_itemName))
        {
            _canShoot = true;
            _aim.CanRotate = true;
            _aimPoint.gameObject.SetActive(true);
            return;
        }
        _canShoot = false;
        _aimPoint.gameObject.SetActive(false);
    }

    public void OnShoot(InputAction.CallbackContext callback)
    {
        if (callback.started && _canShoot == true)
        {
            audioManager.PlaySFX(audioManager.Shoot);
            Instantiate(_arrowPrefab, _aimPoint.position, transform.rotation);
            StartCoroutine(ShootCooldown());
        }
    }

    private IEnumerator ShootCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_shootCooldown);
        _canShoot = true;
    }
}
