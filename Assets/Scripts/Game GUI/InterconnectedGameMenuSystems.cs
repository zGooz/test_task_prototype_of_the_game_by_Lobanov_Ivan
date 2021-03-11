
using UnityEngine;

[RequireComponent(typeof(StatePlayingNow))]
[RequireComponent(typeof(StateWaitingForLaunchOfGame))]
[RequireComponent(typeof(StateWaitingForGameToContinue))]

public class InterconnectedGameMenuSystems : MonoBehaviour
{
    public bool IsOutOfGame => _currentGameState != _playing;

    private GameMenuState _currentGameState;
    private GameMenuState _playing;
    private GameMenuState _waitLaunch;
    private GameMenuState _waitContinue;

    private void Awake()
    {
        _playing = GetComponent<StatePlayingNow>();
        _waitLaunch = GetComponent<StateWaitingForLaunchOfGame>();
        _waitContinue = GetComponent<StateWaitingForGameToContinue>();

        _currentGameState = _waitLaunch;
    }

    public void ChangeStateToPlay()
    {
        _currentGameState = _playing;
    }

    public void ChangeStateToWaitLaunch()
    {
        _currentGameState = _waitLaunch;
    }

    public void ChangeStateToWaitContinueGame()
    {
        _currentGameState = _waitContinue;
    }
} 
