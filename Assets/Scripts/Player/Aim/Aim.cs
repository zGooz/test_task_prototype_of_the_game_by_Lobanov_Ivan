
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class Aim : MonoBehaviour
{
    [SerializeField] private PlayerHandler _handler;
    [SerializeField] private GameObject _player;
    private Transform _transform;
    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = _player.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.position = _playerTransform.position;
    }
}
