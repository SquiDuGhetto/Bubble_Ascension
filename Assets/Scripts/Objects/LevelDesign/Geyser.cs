using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    [SerializeField] private float _force;
    private List<Rigidbody2D> _insideBodys = new();

    private void Update()
    {
        if (_insideBodys.Count > 0)
        {
            foreach (Rigidbody2D body in _insideBodys)
            {
                body.AddForce(Vector2.up * _force);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D body))
        {
            _insideBodys.Add(body);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D body))
        {
            _insideBodys.Remove(body);
        }
    }
}
