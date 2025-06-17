using UnityEngine;
public enum AttackType
{
    CloseRange,
    LongRange
}

[RequireComponent(typeof(EnemyMovement))]
public abstract class Enemy : Character
{
    public EnemyMovement enemyMovement;
    public Transform target; // Düşmanın hedefi, örneğin oyuncu olabilir.
    public float specialAbilityCooldown = 5f; 
    public float specialManaAmount = 100;

    private void Start()
    {
        target = GameObject.Find("Player").transform; // Oyuncu objesini bul ve hedef olarak ata
        enemyMovement = GetComponent<EnemyMovement>();
    }
}
