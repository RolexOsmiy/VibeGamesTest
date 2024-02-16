using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : Character
{
    private void Awake()
    {
        DataInitialize();
    }

    private void Update()
    {
        if (!isDead)
            Attack();
    }

    public override void Attack()
    {
        if (isAttacking && !isDefending)
        {
            currentTime += Time.deltaTime;
            
            if (currentTime >= attackTime)
            {
                animator.SetFloat("AttackIndex", Random.Range(0f,1f));
                Transform closestEnemy = FindClosestEnemy();
                currentTime = 0;
                if (closestEnemy != null)
                {
                    RotateToAsync(closestEnemy, 2f);
                    closestEnemy.GetComponent<IDamage>().Damage();
                }
            }
        }
    }

    public void AttackBtnDown()
    {
        print(CheckForDestinationReached());

        if (!isAttacking && CheckForDestinationReached())
        {
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
    
    public void AttackBtnUp()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
        currentTime = 0;
    }
    
    public void DefendBtnDown()
    {
        if (!isAttacking)
            isDefending = true;
    }
    
    public void DefendBtnUp()
    {
        isDefending = false;
    }
    
    private bool CheckForDestinationReached()
    {
        return Vector3.Distance(transform.position,agent.destination) <= agent.stoppingDistance;
    }
}
