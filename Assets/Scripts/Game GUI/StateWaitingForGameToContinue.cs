
using UnityEngine;

public class StateWaitingForGameToContinue : GameMenuState
{
    [SerializeField] private ButtonClick _gameResumeButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameMenu;

    private void OnEnable()
    {
        _gameResumeButton.Click += ResumeGame;
    }

    private void OnDisable()
    {
        _gameResumeButton.Click -= ResumeGame;
    }

    protected override void ResumeGame()
    {
        _menuSystem.ChangeStateToPlay();
        _gameMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }
}
