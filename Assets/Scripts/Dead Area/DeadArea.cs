
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Transform))]

public class DeadArea : MonoBehaviour
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
        var position = _playerTransform.position;
        position.Set(position.x, 0, position.z);
        _transform.position = position + _vectorToTarget;
    }

    private void OnTriggerExit(Collider collision)
    {
        var instance = collision.gameObject;
        if (instance.TryGetComponent(typeof(PlayerBody), out Component other))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
