using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletTypeAttack : Attack
{
    [Header("Bullet Type Attack")]
    public GameObject projectilePrefab;
    public Vector3 firePoint;
    public Transform bulletsParent;
    public float distanceToPlayer = 1f;
    public float bulletSpeed;
    [SerializeField] List<Bullet> bullets = new();

    private void Awake()
    {
        bulletsParent = new GameObject("BulletsParent").transform;
    }

    protected override void DoThatAttack()
    {
        if (attackManager.myCharacter.target != null)
        {
            Debug.Log("Attacking");
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
            Debug.Log("Attacked");

        }

        base.DoThatAttack();

    }
    Bullet GetBullet()
    {
        Debug.Log("Searching for an inactive bullet...");
        foreach (Bullet bullet in bullets)
        {
            if (!bullet.gameObject.activeSelf)
            {
                return bullet;
            }
        }
        Debug.Log("No inactive bullets found, creating a new one.");
        Bullet newBullet = Instantiate(projectilePrefab).GetComponent<Bullet>();
        newBullet.bulletTypeAttack = this;
        newBullet.transform.SetParent(bulletsParent);
        bullets.Add(newBullet);
        newBullet.gameObject.SetActive(false);
        return newBullet;


    }
}