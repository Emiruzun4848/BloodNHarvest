using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Character
{
    public PlayerMovement playerMovement;
    [SerializeField] float detectRadius = 10f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        SetCloseEnemy();
    }
    void SetCloseEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectRadius);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider col in hits)
        {
            if (col.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.transform;
                }
            }
        }

        target = closestEnemy;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
