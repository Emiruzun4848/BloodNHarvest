using UnityEngine;

public class BasicCloseAttack : Attack
{

    protected override void DoThatAttack()
    {
        if (attackManager.myCharacter.target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, attackManager.myCharacter.target.transform.position);
            if (distanceToTarget <= attackRange)
            {
                HealthStats targetHealthStats = attackManager.myCharacter.target.GetHealthStats();
                if (targetHealthStats != null && targetHealthStats.Health > 0)
                {
                    attackManager.myCharacter.target.TakeDamage(damage, attackPower, attackManager.myCharacter.stats.penetrationStats);
                }
            }
        }
        base.DoThatAttack();
    }
}