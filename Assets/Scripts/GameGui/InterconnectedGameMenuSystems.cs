
using UnityEngine;

[RequireComponent(typeof(StatePlayingNow))]
[RequireComponent(typeof(StateWaitingForLaunchOfGame))]
[RequireComponent(typeof(StateWaitingForGameToContinue))]

public class InterconnectedGameMenuSystems : MonoBehaviour
{
    public GameMenuState CurrentGameState { get; private set; }

    private GameMenuState _playing;
    private GameMenuState _waitLaunch;
    private GameMenuState _waitContinue;

    private void Awake()
    {
        _playing = getComponent<StatePlayingNow>();
        _waitLaunch = getComponent<StateWaitingForLaunchOfGame>();
        _waitContinue = getComponent<StateWaitingForGameToContinue>();

        CurrentGameState = _waitLaunch;
    }

    public bool IsInGame()
    {
        return CurrentGameState == _playing;
    }

    public bool IsOutOfGame()
    {
        return CurrentGameState != _playing;
    }
} 
