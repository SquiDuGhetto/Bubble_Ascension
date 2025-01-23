using System.Collections;
using UnityEngine;

public class PassThroughtPlatfroms : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    private PlayerMovement _playerMovement;
    private bool _isPlayerOnThePlatform;

    private void Update()
    {
        if (_playerMovement != null)
        {
            if (_playerMovement.GetMoveAxis().y < -0.7f && _isPlayerOnThePlatform == true)
            {
                StartCoroutine(PlatformCollider());
            }
        }
    }

    private IEnumerator PlatformCollider()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        _collider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<PlayerMovement>(out _playerMovement))
        {
            _isPlayerOnThePlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _isPlayerOnThePlatform = false;
        }
    }
}
