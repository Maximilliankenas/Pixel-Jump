using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public string stateKey;

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
}
