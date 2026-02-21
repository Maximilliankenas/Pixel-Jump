using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float radius = 0.1f;
    [SerializeField] private string tagName = "Ground";
    public bool isOnGround = false;

    private void FixedUpdate()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius);
        if (collider)
        {
            isOnGround = collider.CompareTag(tagName);
        }
        else
        {
            isOnGround = false;
        }
    }
}
