
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
            DoAttack();
        }
    }
    protected virtual bool TimerElapsed()
    {
        if (isAttacking == false)
        {
            if (attackTimer <= 0)
            {
                AttackCondition();
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
    protected virtual void AttackCondition()
    {

    }
    protected virtual void ResetAttackTimer()
    {
        attackTimer = attackCooldown;
    }
    public virtual void DoAttack()
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