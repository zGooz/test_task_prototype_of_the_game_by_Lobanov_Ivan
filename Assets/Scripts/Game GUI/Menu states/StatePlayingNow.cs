
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatePlayingNow : GameMenuState
{
    [SerializeField] private ButtonClick _gamePauseButton;
    [SerializeField] private ButtonClick _gameReloadButton;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameMenu;

    private void OnEnable()
    {
        _gamePauseButton.Click += SuspendGame;
        _gameReloadButton.Click += ReloadGame;
    }

    private void OnDisable()
    {
        _gamePauseButton.Click -= SuspendGame;
        _gameReloadButton.Click -= ReloadGame;
    }

    protected override void SuspendGame() 
    {
        _menuSystem.ChangeStateToWaitContinueGame();
        _pauseMenu.SetActive(true);
        _gameMenu.SetActive(false);
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
