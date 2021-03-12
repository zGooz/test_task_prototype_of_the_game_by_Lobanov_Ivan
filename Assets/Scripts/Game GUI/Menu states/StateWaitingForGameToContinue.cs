
using UnityEngine;

public class StateWaitingForGameToContinue : GameMenuState
{
    [SerializeField] private ButtonClick _gameResumeButton;
    [SerializeField] private ButtonClick _gameQuitToMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameMenu;

    private void OnEnable()
    {
        _gameResumeButton.Click += ResumeGame;
        _gameQuitToMenu.Click += QuitToMenu;
    }

    private void OnDisable()
    {
        _gameResumeButton.Click -= ResumeGame;
        _gameQuitToMenu.Click -= QuitToMenu;
    }

    protected override void ResumeGame()
    {
        _menuSystem.ChangeStateToPlay();
        _gameMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    protected override void QuitToMenu()
    {
        _menuSystem.ChangeStateToWaitLaunch();
        _gameMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
