
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction Click;

    public void OnPointerDown(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
