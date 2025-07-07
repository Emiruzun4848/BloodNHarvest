using UnityEngine;

public class BulletTypeAttack : Attack
{
    public GameObject projectilePrefab;
    public Vector3 firePoint;
    public float bulletDamage = 10f; // Damage dealt by the bullet
    public float projectileSpeed = 20f;
    public float bulletLifeTime = 5f; // Time before the bullet is destroyed
    public float bulletRange = 100f; // Maximum distance the bullet can travel
    public bool IsPenetrationSkill; // Amount of penetration the bullet has
    public float PenetrationLimit; // Amount of penetration the bullet has
    protected override void DoThatAttack()
    {
       
    }
    public virtual void DoAttack()
    {
       

        base.DoAttack();
    }
}   