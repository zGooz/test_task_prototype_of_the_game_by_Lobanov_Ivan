
using UnityEngine;

public abstract class GameMenuState : MonoBehaviour
{
   protected virtual void RunGame() {}
   protected virtual void SuspendGame() {}
   protected virtual void ResumeGame() {}
}
