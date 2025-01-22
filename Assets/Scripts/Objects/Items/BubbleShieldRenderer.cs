using UnityEngine;

public class BubbleShieldRenderer : MonoBehaviour
{
    [SerializeField] private GameObject _renderer;

    public void OnInventoryChange(PlayerInventory inventory)
    {
        if (inventory.HasItem("BubbleShield"))
        {
            _renderer.SetActive(true);
            return;
        }
        _renderer.SetActive(false);
    }
}
