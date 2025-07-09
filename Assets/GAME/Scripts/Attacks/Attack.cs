
using UnityEngine;
using System.Collections;
using System;
using System.Timers;


[RequireComponent(typeof(AttackManager))]
public abstract class Attack : MonoBehaviour
{
    public AttackManager attackManager;
    public AttackType attackType;
    public AttackPower attackPower;

    public float damage = 10f;
    public float attackCooldown = 1f;
    protected float attackTimer = 0f;
    public float attackRange = 2f;
    public bool attackCondition = true;
    public bool canAttack = true;
    public bool isAttacking = false;

    protected virtual void Start()
    {
        attackManager = GetComponent<AttackManager>();
    }

    protected virtual void Update()
    {
        if (TimerElapsed())
        {
            AttackCommand();
        }
    }
    protected virtual bool TimerElapsed()
    {
        if (isAttacking == false)
        {
            if (attackTimer <= 0)
            {
                if (!IsNullTarget())
                {
                    AttackCondition();
                }

                if (canAttack && attackCondition)
                {
                    return true;
                }
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }

        return false;
    }
    protected bool IsNullTarget()
    {
        if (attackManager.myCharacter.target == null)
        {
            attackCondition = false;
            return true;
        }
        return false;
    }
    protected virtual void AttackCondition()
    {
        float distanceToTarget = Vector3.Distance(transform.position, attackManager.myCharacter.target.transform.position);
        if (distanceToTarget <= attackRange)
        {
            HealthStats targetHealthStats = attackManager.myCharacter.target?.GetHealthStats();
            if (targetHealthStats != null && targetHealthStats.Health > 0)
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
    protected virtual void ResetAttackTimer()
    {
        attackTimer = attackCooldown;
    }
    public virtual void AttackCommand()
    {
        StartCoroutine(PrepareAttack());
    }
    protected virtual IEnumerator PrepareAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        DoThatAttack();

    }
    protected virtual void DoThatAttack()
    {
        AfterAttack();
    }
    protected virtual void AfterAttack()
    {
        isAttacking = false;
        ResetAttackTimer();
    }


}