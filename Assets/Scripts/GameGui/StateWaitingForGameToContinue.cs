
public class StateWaitingForGameToContinue : GameMenuState
{
   protected override void SuspendGame() 
   {
       _playing.ChangeStateToWaitLaunch();
   }
}
