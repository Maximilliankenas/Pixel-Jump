using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public event EventHandler OnPlayerDied;

    [SerializeField] private AudioClip hurtSFX;

    public void ReceiveDamage(int damageAmount)
    {
        Debug.Log("Player receive damage");
        OnPlayerDied?.Invoke(this, EventArgs.Empty);
        AudioManager.Instance.PlaySFX(hurtSFX);
    }
}
