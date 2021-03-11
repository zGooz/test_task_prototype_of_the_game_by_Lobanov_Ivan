
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Transform _playerTransform;
    private Vector3 _vectorToTarget;
    private Transform _transform;

    private void Awake()
    {
        _playerTransform = _player.transform;
        _vectorToTarget = transform.position - _playerTransform.position;
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.position = _playerTransform.position + _vectorToTarget;
    }
}
