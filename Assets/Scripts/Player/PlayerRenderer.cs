using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [Header("Invincibility")]
    [SerializeField] private int _blinkCount = 2;
    [SerializeField] private float _blinkDuration = 0.5f;
    [SerializeField] private UnityEvent _onInvincibilityEnd;

    public void StartInvincibilityRendering()
    {
        StartCoroutine(Invincibility());
    }

    IEnumerator Invincibility()
    {
        for (int i = 0; i < _blinkCount; i++)
        {
            _renderer.enabled = false;
            yield return new WaitForSeconds(_blinkDuration);
            _renderer.enabled = true;
            yield return new WaitForSeconds(_blinkDuration);
        }
        _onInvincibilityEnd.Invoke();
    }

    public void Crouch(bool isCrouch)
    {
        if (isCrouch)
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            return;
        }
        transform.localScale = Vector3.one;
    }
}
