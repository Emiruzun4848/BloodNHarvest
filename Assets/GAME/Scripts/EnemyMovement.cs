using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    public Enemy enemy;
    [Header("Movement Settings")]
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
    public void Move()
    {
        Vector3 newpos = enemy.target.position - transform.position;
        newpos = newpos.normalized * enemy.stats.speedStats.Speed * Time.deltaTime;
        transform.position += newpos;
    }
}
