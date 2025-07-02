using UnityEngine;


[RequireComponent(typeof(EnemyMovement))]
public class Enemy : EnemyCharacter
{
    [Space(3)]
    [Header("Enemy Settings")]
    public EnemyMovement enemyMovement;
    public AttackManager attackManager;

    private void Awake()
    {
        target = GameObject.Find("Player").GetComponent<BaseCharacter>(); // Oyuncu objesini bul ve hedef olarak ata
        enemyMovement = GetComponent<EnemyMovement>();
        attackManager = GetComponent<AttackManager>();
    }

    public void Pause()
    {
        attackManager.CanAttack = false;
        enemyMovement.canMovable = false;
    }
    public void Resume()
    {
        attackManager.CanAttack = true;
        enemyMovement.canMovable = true;
    }
}
