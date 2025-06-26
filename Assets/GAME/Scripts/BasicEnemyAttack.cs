using UnityEngine;

public class BasicEnemyAttack : Attack
{
    public float attackRange = 2f;
    public float attackDamage = 10f;
    protected override void AttackCondition()
    {
        if (attackManager.myCharacter.target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, attackManager.myCharacter.target.transform.position);
            if (distanceToTarget <= attackRange)
            {
                if (attackManager.myCharacter.target != null && attackManager.myCharacter.target.stats.healthStats.Health>0)
                {
                    attackCondition = true;
                }
                else
                {
                    attackCondition = false;
                }
            }
            else
            {
                attackCondition = false;
            }
        }
        else
        {
            attackCondition = false;
        }
    }
    protected override void DoThatAttack()
    {
        if (attackManager.myCharacter.target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, attackManager.myCharacter.target.transform.position);
            if (distanceToTarget <= attackRange)
            {
                if (attackManager.myCharacter.target != null && attackManager.myCharacter.target.stats.healthStats.Health>0)
                {
                    attackManager.myCharacter.target.TakeDamage(attackDamage, attackPower, attackManager.myCharacter.stats.penetrationStats);
                }
            }
        }
        base.DoThatAttack();
    }
}