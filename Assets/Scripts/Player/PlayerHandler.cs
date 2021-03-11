
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event UnityAction Fire;
    public Vector2 ShotDirection => -1 * _direction;
    
    private Vector2 _origin = Vector2.zero;
    private Vector2 _direction = Vector2.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        _direction = Vector2.zero;
        _origin = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Fire?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var heldPosition = eventData.position;
        _direction = heldPosition - _origin;
    }
}
