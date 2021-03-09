
using UnityEngine;

public class StateWaitingForLaunchOfGame : GameMenuState
{
    [SerializeField] private ButtonClick _gameStartButton;
    [SerializeField] private ButtonClick _gameEndButton;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameMenu;

    private void OnEnable()
    {
        _gameStartButton.Click += RunGame;
        _gameEndButton.Click += QuitGame;
    }

    private void OnDisable()
    {
        _gameStartButton.Click -= RunGame;
        _gameEndButton.Click -= QuitGame;
    }

    protected override void RunGame() 
    {
        _menuSystem.ChangeStateToPlay();
        _gameMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
