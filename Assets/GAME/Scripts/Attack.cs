using UnityEngine;

public class Attack : MonoBehaviour
{
    public Character character;
    public float attackRange = 2f; // Close range attack distance
    public float attackCooldown = 1f; // Time between attacks
    private float currentAttackCooldown = 0f;
    public bool CanAttackable = true;
    private void Awake()
    {
         character = GetComponent<Enemy>();
        currentAttackCooldown = 0f;
    }
    private void Update()
    {
        currentAttackCooldown -= Time.deltaTime;
        if (CanAttackable && currentAttackCooldown <= 0)
        {
            if (character.target != null && CanAttack())
            {
                PerformAttack();
            }
        }
    }
    private bool CanAttack()
    {
        return Vector3.Distance(transform.position, character.target.position) <= attackRange;
    }
    private void PerformAttack()
    {
        // Implement the attack logic here
        Debug.Log("Enemy attacks!");
        currentAttackCooldown = attackCooldown; // Reset cooldown after attack
    }
}