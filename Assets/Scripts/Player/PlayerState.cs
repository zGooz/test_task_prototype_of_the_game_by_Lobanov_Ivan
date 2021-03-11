
using UnityEngine;

/// TODO : Change to mesh collider
[RequireComponent(typeof(BoxCollider))]

public class PlayerState : MonoBehaviour
{
    public bool IsImmovable { get; private set; } = true;

    private Transform _transform;
    private Vector3 _oldPosition;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _oldPosition = _transform.position;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsImmovable)
        {

        }
    }

    private void Update()
    {
        IsImmovable = (_transform.position == _oldPosition);
        _oldPosition = _transform.position;
    }
}
