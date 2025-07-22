using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TargetTypeAttack : Attack
{
    [Header("Bullet Type Attack")]
    public GameObject projectilePrefab;
    public Vector3 firePoint;
    public Transform bulletsParent;
    public float distanceToPlayer = 1f;
    public float bulletSpeed;
    [SerializeField] List<TargetBullet> bullets = new();

    private void Awake()
    {
        bulletsParent = new GameObject("BulletsParent").transform;
    }

    protected override void DoThatAttack()
    {
        if (attackManager.myCharacter.target != null)
        {
            Bullet bullet = GetBullet();
            Vector3 basePos = attackManager.myCharacter.target.transform.position - transform.position;
            Vector3 startPos = Vector3.Normalize(basePos) * distanceToPlayer + transform.position;
            bullet.transform.position = startPos;
            bullet.direction = basePos.normalized;
            bullet.speed = bulletSpeed;
            basePos.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(basePos);
            bullet.transform.rotation = targetRotation;
            bullet.ResetVariable();
            bullet.gameObject.SetActive(true);

        }

        base.DoThatAttack();

    }
    Bullet GetBullet()
    {
        foreach (TargetBullet bullet in bullets)
        {
            if (!bullet.gameObject.activeSelf)
            {
                return bullet;
            }
        }
        TargetBullet newBullet = Instantiate(projectilePrefab).GetComponent<TargetBullet>();
        newBullet.fatherAttack = this;
        newBullet.transform.SetParent(bulletsParent);
        bullets.Add(newBullet);
        newBullet.gameObject.SetActive(false);
        return newBullet;


    }
}   