using UnityEngine;

public class WalkState : BaseState
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioClip walkSFX;
    [SerializeField] private float walkSFXPerSecond = 4.0f;

    public float speed = 0;
    public int direction = 0;

    private float walkSFXTimer = 0.0f;

    public override void EnterState()
    {
        walkSFXTimer = 0.0f;
    }
    public override void ExitState()
    {
        rb.linearVelocityX = 0;
    }
    public override void UpdateState()
    {
        walkSFXTimer += Time.deltaTime;
        if (walkSFXTimer > (1.0 / walkSFXPerSecond))
        {
            AudioManager.Instance.PlaySFX(walkSFX);
            walkSFXTimer = 0.0f;
        }
    }
    public override void FixedUpdateState()
    {
        rb.linearVelocityX = speed * direction;
    }
}
