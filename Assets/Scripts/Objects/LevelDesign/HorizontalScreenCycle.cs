using UnityEngine;

public class HorizontalScreenCycle : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 newPos = new();
            newPos.y = other.transform.position.y;
            newPos.x = _teleportPosition.position.x;
            other.transform.position = newPos;
        }
    }
}
