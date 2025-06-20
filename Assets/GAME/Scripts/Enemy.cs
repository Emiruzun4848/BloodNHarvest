using UnityEngine;
public enum AttackType
{
    CloseRange,
    LongRange
}

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : Character
{
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    public float specialAbilityCooldown = 5f; 
    public float specialManaAmount = 100;

    private void Awake()
    {
        target = GameObject.Find("Player").transform; // Oyuncu objesini bul ve hedef olarak ata
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void Pause()
    {
        enemyAttack.CanAttackable = false;
        enemyMovement.canMovable = false;
    }
    public void Resume()
    {
        enemyAttack.CanAttackable = true;
        enemyMovement.canMovable = true;
    }
}
