using UnityEngine;

public class ItemObtainer : MonoBehaviour
{
    [SerializeField] private ScriptableItem _item;
    private PlayerInventory _inventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInventory>(out _inventory) == true)
        {
            _inventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
}
