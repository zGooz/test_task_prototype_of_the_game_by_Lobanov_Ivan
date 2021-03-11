
using UnityEngine;

public class AimRenderer : MonoBehaviour
{
    [SerializeField] private PlayerHandler _handler;
    [SerializeField] private GameObject _player;
    private PlayerState _playerState;
    private LineRenderer _lineRenderer;
    private Transform _transform;
    private PlayerBody _playerBody;
    private float _referenceLineLength = 5f;

    private void Awake()
    {
        _playerState = _player.GetComponent<PlayerState>();
        _lineRenderer = GetComponent<LineRenderer>();
        _transform = GetComponent<Transform>();
        _playerBody = _player.GetComponent<PlayerBody>();
    }

    private void Update()
    {
        if (_playerState.IsImmovable)
        {
            var angle = _handler.Angle * Mathf.Deg2Rad;
            var sin = Mathf.Sin(angle);
            var cos = Mathf.Cos(angle);

            var ratio = Mathf.Clamp(_handler.ShotPower / _playerBody.MaxPullLenght, 0, 1);
            var length = _referenceLineLength * ratio;
            var direction = new Vector3(length * cos, length * sin, 0f);

            _lineRenderer.SetPosition(0, _transform.position);
            _lineRenderer.SetPosition(1, _transform.position + direction);
        }
    }
}
