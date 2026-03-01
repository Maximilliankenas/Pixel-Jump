using System;
using UnityEngine;

public class EndPole : MonoBehaviour
{
    public event EventHandler OnEndPoleReached;

    [SerializeField] private string playerTagName = "Player";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTagName))
        {
            OnEndPoleReached?.Invoke(this, EventArgs.Empty);
        }
    }
}
