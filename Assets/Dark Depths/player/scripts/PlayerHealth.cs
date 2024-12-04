using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth: MonoBehaviour
{
    private Animator _animator;
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart, halfHeart;
    private Collider2D[] _colliders;
    
    public int maxHealth;
    private float currentHealth = 0;

    private void Awake()
    {
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        _colliders = GetComponents<Collider2D>();
    }
    
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            int heartStatusReminder = (int)Mathf.Clamp(currentHealth - (i * 2), 0, 2);
            if (heartStatusReminder == 0)
            {
                hearts[i].sprite = emptyHeart;
            }
            else if (heartStatusReminder == 1)
            {
                hearts[i].sprite = halfHeart;
            }
            else if (heartStatusReminder == 2)
            {
                hearts[i].sprite = fullHeart;
            }
        }
    }

    public void TakeDamage(float damageTaken)
    {
        _animator.SetTrigger("Hitted");
        currentHealth -= damageTaken;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        GameOver.instance.Setup(5);
        _animator.SetBool("IsDead", true);
        foreach (Collider2D collider2D in _colliders)
        {
            collider2D.enabled = false;
        }
        enabled = false;
    }
}

