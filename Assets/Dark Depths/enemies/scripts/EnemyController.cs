using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] public Transform target; 
    private NavMeshAgent _navMeshAgent;
    private Collider2D[] _colliders;
    public Transform attackPoint;
    public LayerMask PlayerMask;
    
    public float attackRange = 0.5f;
    public float chaseRadius = 10f; 
    public int maxHealth = 100;
    private int _currentHealth = 0;
    public float attackRate = 0.8f;
    private float _nextAttackTime = 0f;
    public float _attackDistance = 2f;
    
    private void Awake()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _colliders = GetComponents<Collider2D>();
        
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }
    
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        
        if (distanceToTarget <= chaseRadius)
        {
            ChaseTarget();
        }
        else
        {
            StopChasing();
        }

        CheckAttack(distanceToTarget);
        
    }

    private void CheckAttack(float distanceToTarget)
    {
        if (distanceToTarget <= _attackDistance)
        {
            if (Time.time >= _nextAttackTime)
            {
                _animator.SetTrigger("IsAttacking");
                _nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Attack()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, PlayerMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(1f);
        }
    }
    
    public void TakeDamage(int damageTaken)
    {
        _animator.SetTrigger("Hitted");
        _currentHealth -= damageTaken;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool("IsDead", true);
        foreach (Collider2D collider2D in _colliders)
        {
            collider2D.enabled = false;
        }
        enabled = false;
        StartCoroutine(WaitForDeathAnimation());
        WinGameMenu.instance.CheckForVictory();
    }
    
    private IEnumerator WaitForDeathAnimation()
    {
        float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animationLength);

        gameObject.SetActive(false);
    }
    
    void ChaseTarget()
    {
        _animator.SetBool("IsWalking", true);
        _navMeshAgent.SetDestination(target.position);

        Vector3 direction = (target.position - transform.position).normalized;

        if (direction.x > 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0) 
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void StopChasing()
    {
        _animator.SetBool("IsWalking", false);
        _navMeshAgent.ResetPath();
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
}
