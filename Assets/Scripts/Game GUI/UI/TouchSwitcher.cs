
using UnityEngine;

public class TouchSwitcher : MonoBehaviour
{
    [SerializeField] private ButtonClick _gameStartButton;
    [SerializeField] private ButtonClick _gameResumeButton;
    [SerializeField] private ButtonClick _gameQuitToMenu;
    [SerializeField] private ButtonClick _gamePauseButton;
    [SerializeField] private GameObject _totchControl;

    private void OnEnable()
    {
        _gameStartButton.Click += OnSelf;
        _gameResumeButton.Click += OnSelf;
        _gameQuitToMenu.Click += OffSelf;
        _gamePauseButton.Click += OffSelf;
    }

    private void OnDisable()
    {
        _gameStartButton.Click -= OnSelf;
        _gameResumeButton.Click -= OnSelf;
        _gameQuitToMenu.Click -= OffSelf;
        _gamePauseButton.Click -= OffSelf;
    }

    private void OnSelf()
    {
        _totchControl.SetActive(true);
    }

    private void OffSelf()
    {
        _totchControl.SetActive(false);
    }
}
