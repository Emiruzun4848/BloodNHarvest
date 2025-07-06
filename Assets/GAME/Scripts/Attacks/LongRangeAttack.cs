using UnityEngine;

public class LongRangeAttack : Attack
{
    public GameObject projectilePrefab;
    public Vector3 firePoint;
    public float projectileSpeed = 20f;
    protected override void DoThatAttack()
    {
       
    }
    public virtual void DoAttack()
    {
       

        base.DoAttack();
    }
}   