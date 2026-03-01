using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public event EventHandler OnPlayerDied;

    public void ReceiveDamage(int damageAmount)
    {
        Debug.Log("Player receive damage");
        OnPlayerDied?.Invoke(this, EventArgs.Empty);
    }
}
