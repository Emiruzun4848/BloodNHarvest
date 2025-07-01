using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Character
{
    public bool isAlive = true;
    public PlayerMovement playerMovement;
    public AttackManager attackManager;
    public NightUIManager nightUIManager;
    [SerializeField] float detectRadius = 10f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        attackManager = GetComponent<AttackManager>();

    }
    private void Start()
    {

        nightUIManager = NightUIManager.Instance;
        nightUIManager.player = this;
        stats.healthStats.onHealthChanged += nightUIManager.ChangePlayerHealthUI;

    }
    public void Pause()
    {
        attackManager.CanAttack = false;
        playerMovement.CanMoveable = false;
    }
    public void Resume()
    {
        attackManager.CanAttack = true;
        playerMovement.CanMoveable = true;
    }
    protected override void Update()
    {
        SetCloseEnemy();
        base.Update();
    }
    protected override void AutoRegen()
    {
        if (isAlive)
        {
            base.AutoRegen();
        }

    }
    protected override void BeforeDie()
    {

        GameManager.Instance?.PauseGame();
        isAlive = false;
        Debug.Log($"{gameObject.name} is about to die.");
        base.BeforeDie();
    }
    protected override void AfterDie()
    {
        Destroy(gameObject, 5f);
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
            target = closestEnemy.GetComponent<Character>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
