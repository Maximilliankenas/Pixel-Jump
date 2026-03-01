using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int currentDirection = 1;

    public void UpdateWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void UpdateMidair(bool isMidair)
    {
        animator.SetBool("isMidair", isMidair);
    }

    public void UpdateFacingDirection(int newDirection)
    {
        if(newDirection == 0) return;
        if (currentDirection != newDirection)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            currentDirection = newDirection;
        }
    }
}
