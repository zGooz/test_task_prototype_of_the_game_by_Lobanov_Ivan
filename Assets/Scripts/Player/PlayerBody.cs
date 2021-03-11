
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerState))]

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private PlayerHandler _inputControl;
    [SerializeField] private InterconnectedGameMenuSystems _system;
    private readonly float _length = 0.03f;
    private readonly float _height = 0.06f;
    private Rigidbody _body;
    private PlayerState _state;

    private const float MAX_LENGTH = 3f;
    private const float MAX_HEIGHT = 5f;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _state = GetComponent<PlayerState>();
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
            // TODO : Remake method

            var sourceDirection = _inputControl.ShotDirection;
            var x = Mathf.Min(_length * sourceDirection.x, MAX_LENGTH);
            var y = Mathf.Min(_height * sourceDirection.y, MAX_HEIGHT);
            var force = new Vector3(x, y, 0);

            _body.AddForce(force, ForceMode.Impulse);
        }
    }
}
