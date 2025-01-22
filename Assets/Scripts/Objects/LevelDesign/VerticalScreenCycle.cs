using UnityEngine;

public class VerticalScreenCycle : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 newPos = new();
            newPos.x = other.transform.position.x;
            newPos.y = _teleportPosition.position.y;
            other.transform.position = newPos;
        }
    }
}
