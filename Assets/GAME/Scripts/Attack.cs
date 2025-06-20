using System.Collections;
using System.Timers;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public AttackManager attackManager;
    public AttackType attackType;
    public AttackPower attackPower;
    public float damage = 10f;
    public float attackCooldown = 1f;
    protected float attackTimer = 0f;
    public bool canAttack = true;
    public bool isAttacking = false;
    protected virtual void Start()
    {
        // Initialize attack properties if needed
    }

    protected virtual void Update()
    {
     Att();
    }
    protected void Att()
    {
        if (isAttacking == false )
        {
            if(attackTimer>=0)
            attackTimer -= Time.deltaTime;
            else
            {
                if (canAttack)
                {
                    DoAttack();
                }
            }
        }
    }
    public void DoAttack()
    {
       StartCoroutine(PrepareAttack());
    }
    protected IEnumerator PrepareAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        DoThatAttack();

    }
    protected virtual void DoThatAttack()
    {
        isAttacking=false;
    }


}