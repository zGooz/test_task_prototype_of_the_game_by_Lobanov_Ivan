
using UnityEngine;

public class StatePlayingNow : GameMenuState
{
    [SerializeField] private ButtonClick _gamePauseButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameMenu;

    private void OnEnable()
    {
        _gamePauseButton.Click += SuspendGame;
    }

    private void OnDisable()
    {
        _gamePauseButton.Click -= SuspendGame;
    }

    protected override void SuspendGame() 
    {
        _menuSystem.ChangeStateToWaitContinueGame();
        _pauseMenu.SetActive(true);
        _gameMenu.SetActive(false);
    }
}
