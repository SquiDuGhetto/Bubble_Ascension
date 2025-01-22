using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ItemList")]
public class ScriptableItemList : ScriptableObject
{
    public List<ItemObtainer> Items;
}
