
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]

public class PlayerBody : MonoBehaviour
{
    public float MaxPullLenght => _maxPullLength;
    public Vector3 StartPosition => _startPosition;

    [SerializeField] private PlayerHandler _inputControl;
    [SerializeField] private InterconnectedGameMenuSystems _system;
    private Rigidbody _body;
    private PlayerState _state;
    private Transform _transform;
    private Vector3 _startPosition;
    private float _maxPullLength;
    private readonly float _speed = 6f;

    private void Awake()
    {
        _state = GetComponent<PlayerState>();
        _body = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;

        var ww = Screen.width * Screen.width;
        var hh = Screen.height * Screen.height;
        _maxPullLength = Mathf.Sqrt(ww + hh);
    }

    private void OnEnable()
    {
        _inputControl.Fire += Fire;
    }

    private void OnDisable()
    {
        _inputControl.Fire -= Fire;
    }

    private void Fire()
    {
        if (_system.IsOutOfGame)
        {
            return;
        }

        if (_state.IsImmovable)
        {
            var power = _inputControl.ShotPower;
            var angle = _inputControl.Angle * Mathf.Deg2Rad;
            var ratio = Mathf.Clamp(power / _maxPullLength, 0, 1);
            var cos = Mathf.Cos(angle);
            var sin = Mathf.Sin(angle);
            var force = new Vector3(ratio * cos, ratio * sin, 0);

            _body.AddForce(_speed * force, ForceMode.Impulse);
        }
    }
}
