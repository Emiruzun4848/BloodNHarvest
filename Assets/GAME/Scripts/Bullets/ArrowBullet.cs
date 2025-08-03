using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ArrowBullet : Bullet
{
    [Header("Arrow Bullet Variables")]

    private BoxCollider myCollider;

    protected List<BaseCharacter> hitedEnemies = new List<BaseCharacter>();

    public int lifeEnemyHits = 5;
    public int baseLifeEnemyHits;
    protected override void Awake()
    {
        myCollider = GetComponent<BoxCollider>();
        base.Awake();
    }
    protected override void MoveBullet()
    {
        transform.position += direction * speed * Time.deltaTime;
        Debug.Log("Bullet has been Moved ");
        ControlIsHitEnemy();
    }
    protected override void Update()
    {
        base.Update();
    }
    public override void ResetVariable()
    {
        base.ResetVariable();
        lifeEnemyHits = baseLifeEnemyHits;
        hitedEnemies.Clear();
    }
    protected virtual void ControlIsHitEnemy()
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
    protected override void ControlConditions()
    {
        Debug.Log("Control Conditions Called");
        baseLifetime -= Time.deltaTime;
        if (baseLifetime <= 0f || baseLifeEnemyHits <= 0)
        {
            baseIsEnabled = false;
            gameObject.SetActive(false);
        }
        else
        {
            ControlIsHitEnemy();
        }
    }

    protected override void HitEnemy(Enemy enemy)
    {
        if (hitedEnemies.Contains(enemy))
        {
            return;
        }
        hitedEnemies.Add(enemy);

        enemy.TakeDamage(baseDamage, fatherAttack.attackPower, myCharacter.stats.penetrationStats);
        baseLifeEnemyHits--;
    }
}