
using UnityEngine;
using System.Collections.Generic;

public class Stairs : MonoBehaviour
{
    public int Top { get { return _top; } set { _top = Mathf.Max(0, value); }}

    private int _top = 0;
    [SerializeField] private GameObject _defaultStep;
    private int _viewSmall = 3;
    private int _viewBig = 4;
    private List<GameObject> _steps  = new List<GameObject>();

    private void Awake()
    {
        _steps.Add(_defaultStep);
    }

    public void AddAnotherStep(GameObject step)
    {
        _steps.Add(step);
    }

    public void UpdateView()
    {
        var size = _steps.Count;
        TurnStepsOnOrOff(size, _viewBig, false);
        TurnStepsOnOrOff(size, _viewSmall, true);
    }

    private void TurnStepsOnOrOff(int size, int view, bool isActive)
    {
        var left = Mathf.Max(0, _top - view);
        var rigth = Mathf.Min(size - 1, _top + view);

        for (var i = left; i <= rigth; i++)
        {
            var step = _steps[i];
            step?.SetActive(isActive);
        }
    }
}
