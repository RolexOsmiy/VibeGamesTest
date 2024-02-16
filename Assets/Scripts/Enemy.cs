using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private LayerMask layerMask;
    private void Awake()
    {
        DataInitialize();
        
        MoveTo(GameManager.Instance.GetFightPoint());
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

        if (!isAttacking && CheckForDestinationReached())
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);
        }
        
        Attack();
    }

    public override void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
        isAttacking = false;
    }
    
    private bool CheckForDestinationReached()
    {
        return agent.pathStatus == NavMeshPathStatus.PathComplete;
    }

    public override void Die()
    {
        base.Die();
        EnemyManager.Instance.RemoveEnemy(this);
        gameObject.layer = layerMask;
    }
}
