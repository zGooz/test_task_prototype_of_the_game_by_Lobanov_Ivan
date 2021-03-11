
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event UnityAction Fire;
    public float ShotPower => _direction.magnitude;
    public float Angle => (_angle >= 360) ? _angle - 360 : _angle;
    
    private Vector2 _origin = Vector2.zero;
    private Vector2 _direction = Vector2.zero;
    private float _angle = 0;

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
        _direction = -1 * (heldPosition - _origin);
        _angle = Mathf.Atan2(_direction.y, _direction.x);
    }
}
