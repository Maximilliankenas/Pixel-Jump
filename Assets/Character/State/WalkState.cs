using UnityEngine;

public class WalkState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    public float speed = 0;
    public int direction = 0;

    public override void EnterState(){}
    public override void ExitState()
    {
        rb.linearVelocityX = 0;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = speed * direction;
    }
}
