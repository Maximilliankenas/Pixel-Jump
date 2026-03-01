using System;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerSprite playerSprite;
    [SerializeField] private StateController stateController;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerData playerData;

    [SerializeField] private WalkState walkState;
    [SerializeField] private JumpState jumpState;
    [SerializeField] private FallState fallState;

    private void Update()
    {
        string currentStateKey = stateController.GetCurrentStateKey();
        if(currentStateKey == "idle")
        {
            if(playerInput.walkInput != 0.0f) ChangeWalk();
            else if(playerInput.jumpInput && groundCheck.isOnGround) ChangeJump();
            else if(!groundCheck.isOnGround) ChangeFall();
        }
        else if(currentStateKey == "walk")
        {
            walkState.direction = Math.Sign(playerInput.walkInput);
            playerSprite.UpdateFacingDirection(Math.Sign(playerInput.walkInput));
            if(playerInput.walkInput == 0.0f) ChangeIdle();
            else if(playerInput.jumpInput && groundCheck.isOnGround) ChangeJump();
            else if(!groundCheck.isOnGround) ChangeFall();
        }
        else if(currentStateKey == "jump")
        {
            jumpState.direction = Math.Sign(playerInput.walkInput);
            playerSprite.UpdateFacingDirection(Math.Sign(playerInput.walkInput));
            if(rb.linearVelocityY < 0) ChangeFall();
        }
        else if(currentStateKey == "fall")
        {
            fallState.direction = Math.Sign(playerInput.walkInput);
            playerSprite.UpdateFacingDirection(Math.Sign(playerInput.walkInput));
            if(groundCheck.isOnGround) ChangeIdle();
        }
    }

    private void ChangeIdle()
    {
        stateController.ChangeState("idle");
        playerSprite.UpdateWalking(false);
        playerSprite.UpdateMidair(false);
    }

    private void ChangeWalk()
    {
        walkState.speed = playerData.walkSpeed;
        stateController.ChangeState("walk");
        playerSprite.UpdateWalking(true);
        playerSprite.UpdateMidair(false);
    }

    private void ChangeJump()
    {
        jumpState.speed = playerData.walkSpeed;
        jumpState.jumpSpeed = playerData.jumpSpeed;
        stateController.ChangeState("jump");
        playerSprite.UpdateWalking(false);
        playerSprite.UpdateMidair(true);
    }

    private void ChangeFall()
    {
        fallState.speed = playerData.walkSpeed;
        stateController.ChangeState("fall");
        playerSprite.UpdateWalking(false);
        playerSprite.UpdateMidair(true);
    }
}
