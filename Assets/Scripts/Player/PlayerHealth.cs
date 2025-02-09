using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour, IHitable
{
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private float _playerStartingHealth = 1f;
    [SerializeField] private UnityEvent _onHit;
    private float _currentHealth;
    private bool _isInvincible = false;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        _currentHealth = _playerStartingHealth;
    }

    public void Hit(float damage)
    {
        if (_isInvincible == true)
            return;

        if (CheckPlayerArmor() == true)
            return;

        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Death();
        }

        _onHit.Invoke();
        SetInvincibility(true);
    }

    private bool CheckPlayerArmor()
    {
        if (_inventory.HasItem("BubbleShield"))
        {
            _inventory.RemoveItem("BubbleShield");
            Debug.Log("Shielded : " + _currentHealth);
            return true;
        }
        return false;
    }

    private void Death()
    {
        audioManager.PlaySFX(audioManager.Death);
        GameManager.Instance.GameEnd(GetComponent<PlayerInput>());
        Destroy(gameObject);
    }

    public void SetInvincibility(bool isEnabled)
    {
        _isInvincible = isEnabled;
    }
}
