using UnityEngine;

public class HorizontalScreenCycle : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Rigidbody2D>(out Rigidbody2D body))
        {
            Vector3 newPos = new();
            newPos.y = other.transform.position.y;
            newPos.x = _teleportPosition.position.x;
            other.transform.position = newPos;
        }
    }
}
