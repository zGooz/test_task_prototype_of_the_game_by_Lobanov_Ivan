
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event UnityAction Fire;
    public float ShotPower => _direction.magnitude;
    public float Angle { get; private set; }

    [SerializeField] private GameObject _aim;
    [SerializeField] private PlayerState _state;
    private Vector2 _origin = Vector2.zero;
    private Vector2 _direction = Vector2.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        _direction = Vector2.zero;
        _origin = eventData.position;

        if (_state.IsImmovable)
        {
            _aim.SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_state.IsImmovable)
        {
            _aim.SetActive(false);
            Fire?.Invoke();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        var heldPosition = eventData.position;
        _direction = -1 * (heldPosition - _origin);
        Angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Angle = (Angle >= 360) ? Angle - 360 : (Angle < 0 ? Angle + 360 : Angle);
    }
}
