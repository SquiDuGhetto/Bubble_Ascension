using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IHitable hit;
        if (other.TryGetComponent<IHitable>(out hit))
        {
            Debug.Log("Damage");
            hit.Hit(_damage);
        }

        Rigidbody2D lasthit;
        if (other.TryGetComponent<Rigidbody2D>(out lasthit))
        {
            lasthit.AddForce((lasthit.position - new Vector2(transform.position.x, transform.position.y - 1.25f)) * 5, ForceMode2D.Impulse);
        }
        Debug.Log(lasthit);
    }
}
