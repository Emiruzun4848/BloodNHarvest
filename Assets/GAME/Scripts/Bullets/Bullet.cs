using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bulet Variables")]
    protected bool isEnabled = true;
    [SerializeField] protected float damage = 10f;
    public float speed = 10f;
    public float lifetime = 5f;
    public byte lifeEnemyHits = 5;

    private BoxCollider myCollider;

    [HideInInspector]
    public BulletTypeAttack bulletTypeAttack;
    public Vector3 direction;
    protected List<Enemy> hitedEnemies = new List<Enemy>();
    private BaseCharacter myCharacter;

    protected bool baseIsEnabled;
    protected float baseDamage,baseSpeed,baseLifetime; 
    protected byte baseLifeEnemyHits;
    protected virtual void Awake()
    {
        myCollider = GetComponent<BoxCollider>();
        Debug.Log("Bullet Awake Called");
        ResetVariable();
    }
    protected virtual void Start()
    {
        myCharacter = bulletTypeAttack.attackManager.myCharacter;
        Debug.Log("Activated");
    }

    protected virtual void Update()
    {
        ControlConditions();
        if (baseIsEnabled)
        {
            MoveBullet();
            ControlHitEnemy();
        }
    }
    public virtual void ResetVariable()
    {
        baseIsEnabled = isEnabled;
        baseDamage = damage;
        baseSpeed = speed;
        baseLifetime = lifetime;
        baseLifeEnemyHits = lifeEnemyHits;
        hitedEnemies.Clear();
    }
    protected virtual void MoveBullet()
    {
        transform.position += direction * baseSpeed * Time.deltaTime;
    }
    protected virtual void ControlHitEnemy()
    {
        Collider[] hits = Physics.OverlapBox(
    transform.position + myCollider.center,
    myCollider.size * 0.5f,
    transform.rotation);

        foreach (Collider hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                HitEnemy(enemy);
                Debug.Log("Çarpýþtý: " + enemy.name);
            }
        }

    }
    protected virtual void ControlConditions()
    {
        baseLifetime -= Time.deltaTime;
        if (baseLifetime > 0f & baseLifeEnemyHits > 0)
        {
            return;
        }
        baseIsEnabled = false;
        gameObject.SetActive(false);


    }
    protected virtual void HitEnemy(Enemy enemy)
    {
        if (hitedEnemies.Contains(enemy))
        {
            return;
        }
        hitedEnemies.Add(enemy);

        enemy.TakeDamage(baseDamage, bulletTypeAttack.attackPower, myCharacter.stats.penetrationStats);
        baseLifeEnemyHits--;

    }
    public float GetDamage()
    {
        return damage;
    }
    protected void OnEnable()
    {
        ResetVariable();
    }
}