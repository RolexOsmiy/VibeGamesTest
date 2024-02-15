using UnityEngine;

public interface IHealth
{
    public int Health { get; set; }
    
    void TakeDamage(int damageAmount);
    
    void Die();

}
