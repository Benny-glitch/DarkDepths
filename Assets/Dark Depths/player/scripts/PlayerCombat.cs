using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator _animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    private readonly float _attackRange = 0.5f;
    private float _nextAttackTime = 0f;
    public float attackRate = 0.8f;
    public int points = 0;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        attackPoint = transform.Find("AttackPoint");
    }

    public void OnAttackMelee(InputValue spaceClicked)
    {
        if (Time.time >= _nextAttackTime)
        {
            if (spaceClicked.isPressed)
            {
                SetAttackingAnimationMeleeAndHit();
                _nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    
    private void SetAttackingAnimationMeleeAndHit()
    {
        _animator.SetTrigger("IsAttackingMelee");
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, enemyLayer);
        
        foreach (Collider2D enemy in hittedEnemies)
        {
            if (enemy.isTrigger)
            {
                enemy.GetComponent<EnemyController>().TakeDamage(25);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
    }
}
