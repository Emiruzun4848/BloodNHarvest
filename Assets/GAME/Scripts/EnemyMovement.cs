using UnityEngine;
public class EnemyMovement : MonoBehaviour, IMovable
{
    public Enemy enemy;
    [Header("Movement Settings")]
    public bool canMovable = true;

    [SerializeField] float yAxis = 1f;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        ApplyYAxis();
        Move();
    }
    void ApplyYAxis()
    {
        Vector3 pos = transform.position;
        pos.y = yAxis;
        transform.position = pos;
    }
    /*
    public void Move()
    {
        Vector3 newpos = enemy.target.position - transform.position;
        newpos = newpos.normalized * enemy.stats.speedStats.Speed * Time.deltaTime;
        transform.position += newpos;
    }
    */
    public void Move()
    {
        if (canMovable)
        {
            Vector3 direction = enemy.target.position - transform.position;
            float distanceToTarget = direction.magnitude;

            float moveDistance = enemy.stats.speedStats.Speed * Time.deltaTime;

            // Eðer hareket mesafesi hedefe olan mesafeden büyükse, hedefin tam üstüne git
            if (moveDistance >= distanceToTarget)
            {
                transform.position = enemy.target.position;
            }
            else
            {
                Vector3 moveVector = direction.normalized * moveDistance;
                transform.position += moveVector;
            }   

        }
    }
}
