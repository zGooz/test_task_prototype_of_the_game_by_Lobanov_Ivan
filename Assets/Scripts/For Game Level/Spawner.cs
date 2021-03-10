
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 StepValue { get; } = new Vector3(1.5f, 1f, 0f);

    [SerializeField] private ButtonClick _gameStartButton;
    [SerializeField] private GameObject _stepPrefab;
    [SerializeField] private GameObject _defaultStep;
    private Stairs _stairs;

    private void Awake()
    {
        _stairs = GetComponent<Stairs>();
    }

    private void OnEnable()
    {
        _gameStartButton.Click += SpawnStep;
        _gameStartButton.Click += ActivateDefaultStep;
    }

    private void OnDisable()
    {
        _gameStartButton.Click -= SpawnStep;
    }

    private void ActivateDefaultStep()
    {
        _defaultStep.SetActive(true);
        _gameStartButton.Click -= ActivateDefaultStep;
    }

    private void SpawnStep()
    {
        var startPosition = _defaultStep.transform.position;
        var startRotation = _defaultStep.transform.rotation;
        var newPosition = startPosition + StepValue;
        var step = Instantiate(_stepPrefab, newPosition, startRotation);

        _stairs.AddAnotherStep(step);
        _stairs.UpdateView();
    }
}
