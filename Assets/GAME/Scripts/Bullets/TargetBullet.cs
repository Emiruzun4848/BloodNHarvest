using UnityEngine;

public class TargetBullet : Bullet
{
    [Header("Arrow Bullet Variables")]
    public BaseCharacter targetCharacter;


    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        targetCharacter = fatherAttack.attackManager.myCharacter.target;
    }
    protected override void MoveBullet()
    {
        if (targetCharacter != null)
        {
            Vector3 direction = targetCharacter.transform.position - transform.position;
            float distanceToTarget = direction.magnitude;

            float step = speed * Time.deltaTime;
            if (step > distanceToTarget)
            {
                HitDamage();
            }
            else
            {
                transform.position += direction.normalized * step;
            }
        }
    }
    protected override void ControlConditions()
    {
        if (targetCharacter == null || !fatherAttack.attackManager.CanAttack)
        {
            SetDisabled();
        }
    }
    protected virtual void HitDamage()
    {
        HealthStats targetHealthStats = targetCharacter.GetHealthStats();
        if (targetHealthStats != null && targetHealthStats.Health > 0)
        {
            targetCharacter.TakeDamage(damage, fatherAttack.attackPower, myCharacter.stats.penetrationStats);

        }

        SetDisabled();
    }
}