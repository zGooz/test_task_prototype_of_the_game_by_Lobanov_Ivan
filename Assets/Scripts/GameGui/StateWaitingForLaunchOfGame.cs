
public class StateWaitingForLaunchOfGame : GameMenuState
{
   protected override void RunGame() 
   {
       _playing.ChangeStateToPlay();
   }
}
