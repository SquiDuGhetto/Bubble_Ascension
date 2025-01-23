using UnityEngine;
using UnityEngine.Events;

public class ItemObtainer : MonoBehaviour
{
    [SerializeField] private ScriptableItem _item;
    // [SerializeField] private GameObject _
    // [SerializeField] private UnityEvent<GameObject> _onObtain;
    private PlayerInventory _inventory;

    public ItemSpawner Spawner { get; set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerInventory>(out _inventory) == true)
        {
            if (_inventory.HasItem(_item.ItemName))
                return;
            if (_inventory.HasItemOfType(_item.ItemType) && _item.ItemType == ItemType.WEAPON)
            {
                _inventory.RemoveAllItemOfType(ItemType.WEAPON);
            }

            _inventory.AddItem(_item);
            // Instantiate();
            // _onObtain.Invoke(other.gameObject);
            Spawner.StartTimer();
            Destroy(gameObject);
        }
    }
}
