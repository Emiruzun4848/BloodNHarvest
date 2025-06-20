using UnityEngine;


[RequireComponent(typeof(EnemyMovement))]
public class Enemy : Character
{
    public EnemyMovement enemyMovement;
    public AttackManager attackManager;

    private void Awake()
    {
        target = GameObject.Find("Player").transform; // Oyuncu objesini bul ve hedef olarak ata
        enemyMovement = GetComponent<EnemyMovement>();
        attackManager = GetComponent<AttackManager>();
    }

    public void Pause()
    {
        //enemyAttack.CanAttackable = false;
        enemyMovement.canMovable = false;
    }
    public void Resume()
    {
        //enemyAttack.CanAttackable = true;
        enemyMovement.canMovable = true;
    }
}
