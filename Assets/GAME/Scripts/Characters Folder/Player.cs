using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : CharacterPlus
{
    [Space(3)]
    [Header("Player Settings")]
    public PlayerMovement playerMovement; // Renamed to avoid ambiguity
    public AttackManager attackManager;
    public NightUIManager nightUIManager;

    [SerializeField] float detectRadius = 10f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Updated reference
        attackManager = GetComponent<AttackManager>();
    }
    private void Start()
    {
        nightUIManager = NightUIManager.Instance;
        nightUIManager.player = this;
        healthStats.onHealthChanged += nightUIManager.ChangePlayerHealthUI;
    }
    public void Pause()
    {
        attackManager.CanAttack = false;
        playerMovement.CanMoveable = false; // Updated reference
    }
    public void Resume()
    {
        attackManager.CanAttack = true;
        playerMovement.CanMoveable = true; // Updated reference
    }
    protected override void Update()
    {
        base.Update();
        SetCloseEnemy();
    }

    void SetCloseEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectRadius);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider col in hits)
        {
            if (col.CompareTag("Enemies"))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.transform;
                }
            }
        }
        if (closestEnemy != null)
            target = closestEnemy.GetComponent<EnemyCharacter>();
    }

    public override void BeforeDie()
    {
        GameManager.Instance?.PauseGame();
        isAlive = false;
        Debug.Log($"{gameObject.name} is about to die.");
        base.BeforeDie();
    }
    public override void AfterDie()
    {
        Destroy(gameObject, 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
