using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour


{
    public Enemy enemy;

    public float attackRange = 2f; // Close range attack distance
    public float attackCooldown = 1f; // Time between attacks
    private float currentAttackCooldown = 0f;
    public bool CanAttackable = true;

    public float attackTime = 0.5f; // Time taken to perform the attack
    bool isAttacking = false;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy.enemyAttack = this;
        currentAttackCooldown = 0f;
    }
    private void Update()
    {
        currentAttackCooldown -= Time.deltaTime;
        if (CanAttackable && !isAttacking)
        {
            if (enemy.target != null && CanAttack())
            {
                StartCoroutine(Attack());
            }
        }
    }
    private bool CanAttack()
    {
        // Update the last attack time
        return currentAttackCooldown <= 0 &&
               Vector3.Distance(transform.position, enemy.target.position) <= attackRange;
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        //Animaton For Preparing Attack
        yield return new WaitForSeconds(attackTime); // Simulate attack time
        isAttacking = false;
        if (CanAttackable)
        {

        }

    }
}