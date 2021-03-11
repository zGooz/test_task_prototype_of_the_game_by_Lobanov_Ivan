
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerState))]

public class PlayerBody : MonoBehaviour
{
    public float MaxPullLenght => _maxPullLength;

    [SerializeField] private PlayerHandler _inputControl;
    [SerializeField] private InterconnectedGameMenuSystems _system;
    [SerializeField] private GameObject _congratulationsOnVictory;
    private Rigidbody _body;
    private PlayerState _state;
    private float _maxPullLength;
    private readonly float _speed = 14f;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _state = GetComponent<PlayerState>();

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

    private void OnCollisionEnter(Collision collision)
    {
        if (_state.IsImmovable)
        {
            var instance = collision.gameObject;
            if (instance.TryGetComponent(typeof(LastStep), out Component step))
            {
                _congratulationsOnVictory.SetActive(true);
            }
        }
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
