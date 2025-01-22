using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<ScriptableItem> _inventory;

    public void AddItem(ScriptableItem item)
    {
        _inventory.Add(item);
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].ItemName == itemName)
            {
                _inventory.Remove(_inventory[i]);
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
}
