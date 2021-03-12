
using UnityEngine;

[RequireComponent(typeof(Stairs))]

public class Spawner : MonoBehaviour
{
    public Vector3 StepValue { get; private set; } = new Vector3(1f, 0f, 1f);

    [SerializeField] private ButtonClick _gameStartButton;
    [SerializeField] private GameObject _stepPrefab;
    [SerializeField] private GameObject _defaultStep;
    [SerializeField] private GameObject _player;
    private Stairs _stairs;
    private readonly int _spawnCount = 10;

    private void Awake()
    {
        _stairs = GetComponent<Stairs>();
    }

    private void OnEnable()
    {
        _gameStartButton.Click += SpawnSteps;
        _gameStartButton.Click += ActivateDefaultStepAndPlayer;
    }

    private void OnDisable()
    {
        _gameStartButton.Click -= SpawnSteps;
    }

    private void ActivateDefaultStepAndPlayer()
    {
        _defaultStep.SetActive(true);
        _player.SetActive(true);
        _gameStartButton.Click -= ActivateDefaultStepAndPlayer;
    }

    private void SpawnSteps()
    {
        var startPosition = _defaultStep.transform.position;
        var startRotation = _defaultStep.transform.rotation;

        for (var i = 0; i < _spawnCount; i++)
        {
            var newPosition = startPosition + _stairs.Size * StepValue;
            newPosition.z = 0;

            var step = Instantiate(_stepPrefab, newPosition, startRotation, transform);

            _stairs.AddAnotherStep(step);

            var y = Random.Range(0.2f, 0.25f);
            StepValue = new Vector3(StepValue.x, y, StepValue.z);
        }
    }
}
