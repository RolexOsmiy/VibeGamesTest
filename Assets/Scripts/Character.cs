using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IAttackable, IDamage, IHealth
{
    public CharacterData characterData;
    public NavMeshAgent agent;
    public Animator animator;
    public bool isDead { get; set; }

    [SerializeField] private LayerMask detectLayer;
    public float attackRange { get; set; }
    public float attackTime { get; set; }
    public float currentTime { get; set; }
    public bool isAttacking { get; set; }
    public bool isDefending { get; set; }

    public int Health { get; set; }
    
    public void DataInitialize()
    {
        attackRange = characterData.attackRange;
        attackTime = characterData.attackTime;
        Health = characterData.maxHealth;
    }
    
    public virtual void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public Transform FindClosestEnemy()
    {
        // get enemies
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, attackRange, detectLayer);

        // find closest
        Transform closestEnemy = null;
        float minDistance = Mathf.Infinity;
        foreach (Collider enemyCollider in enemyColliders)
        {
            float distance = Vector3.Distance(transform.position, enemyCollider.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemyCollider.transform;
            }
        }

        return closestEnemy;
    }

    public virtual void Attack()
    {
        if (isAttacking && !isDefending && !isDead)
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
    
    public async Task RotateToAsync(Transform target, float rotationSpeed)
    {
        while (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.position - transform.position)) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

            await Task.Yield();
        }
    }


    public virtual void Damage()
    {
        if (!isDefending && !isDead)
            TakeDamage(1);
    }

    public virtual void TakeDamage(int damageAmount)
    {
        if (Health >= 1)
            Health -= damageAmount;
        
        if (Health <= 0)
            Die();
        
        GetComponentInChildren<IHealthDisplay>().UpdateHealthDisplay();
    }

    public virtual void Die() 
    {
        isDead = true;
        
        animator.Play("Death");
        animator.SetBool("isAttacking", false);
        
        isAttacking = false;
        isDefending = false;
    }
}
