using UnityEngine;

public enum ItemType
{
    EQUIPMENT,
    WEAPON
}

[CreateAssetMenu(fileName = "I_", menuName = "Item")]
public class ScriptableItem : ScriptableObject
{
    public string ItemName;
    public ItemType ItemType;
}
