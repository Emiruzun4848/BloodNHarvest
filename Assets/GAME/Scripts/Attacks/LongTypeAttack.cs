using UnityEngine;

public class LongTypeAttack : Attack
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