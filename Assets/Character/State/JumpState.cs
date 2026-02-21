using UnityEngine;

public class JumpState : BaseState
{
    [SerializeField] private Rigidbody2D rb;

    public float speed = 0;
    public int direction = 0;
    public float jumpSpeed = 0;

    public override void EnterState()
    {
        rb.linearVelocityY = jumpSpeed;
    }
    public override void ExitState(){}
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = speed * direction;
    }
}
