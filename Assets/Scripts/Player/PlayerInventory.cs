using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ScriptableItem> _inventory;
    [SerializeField] private UnityEvent<PlayerInventory> _onInventoryChange;

    public void AddItem(ScriptableItem item)
    {
        _inventory.Add(item);
        _onInventoryChange.Invoke(this);
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].ItemName == itemName)
            {
                _inventory.Remove(_inventory[i]);
                _onInventoryChange.Invoke(this);
                return;
            }
        }
    }

    public bool HasItem(string itemName)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].ItemName == itemName)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasItemOfType(ItemType type)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].ItemType == type)
            {
                return true;
            }
        }
        return false;
    }
}
