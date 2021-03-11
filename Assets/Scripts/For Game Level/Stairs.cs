
using UnityEngine;
using System.Collections.Generic;

public class Stairs : MonoBehaviour
{
    public int Size => _steps.Count;

    [SerializeField] private GameObject _defaultStep;
    private readonly List<GameObject> _steps = new List<GameObject>();

    private void Awake()
    {
        _steps.Add(_defaultStep);
    }

    public void AddAnotherStep(GameObject step)
    {
        _steps.Add(step);
    }
}
