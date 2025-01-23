using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletBody;
    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private float _damage = 1f;
    private bool _canMove = true;

    private void FixedUpdate()
    {
        if (_canMove == true)
            _bulletBody.velocity = (Vector2)transform.right * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<IHitable>(out IHitable hit))
        {
            hit.Hit(_damage);
        }
        Destroy(gameObject);
    }
}
