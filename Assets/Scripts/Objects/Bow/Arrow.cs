using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _arrowBody;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _damage = 1f;
    private bool _canMove = true;
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (_canMove == true)
            _arrowBody.velocity = (Vector2)transform.right * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _canMove = false;
        _arrowBody.velocity = Vector2.zero;
        transform.parent = other.transform;
        if (other.collider.TryGetComponent<IHitable>(out IHitable hit))
        {
            hit.Hit(_damage);
        }
        _collider.enabled = false;
        Destroy(gameObject, 2);
    }
}
