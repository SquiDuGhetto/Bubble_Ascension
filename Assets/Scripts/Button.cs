using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        _onClick.Invoke();
    }
}
