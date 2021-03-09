
using UnityEngine;

[RequireComponent(typeof(InterconnectedGameMenuSystems))]

public abstract class GameMenuState : MonoBehaviour
{
    protected InterconnectedGameMenuSystems _menuSystem;

    private void Awake()
    {
        _menuSystem = GetComponent<InterconnectedGameMenuSystems>();
    }

    protected virtual void RunGame() {}
    protected virtual void SuspendGame() {}
    protected virtual void ResumeGame() {}
}
