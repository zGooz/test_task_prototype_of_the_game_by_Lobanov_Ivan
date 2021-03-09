
public class StatePlayingNow : GameMenuState
{
    protected override void SuspendGame() 
    {
        _playing.ChangeStateToWaitContinueGame();
    }

    protected override void ResumeGame()
    {
        _playing.ChangeStateToPlay();
    }
}
