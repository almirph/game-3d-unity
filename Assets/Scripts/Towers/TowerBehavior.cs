using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private float bulletHeight;
    [SerializeField] private float turnSpeed;

    private float bulletTimer;

    private void Start()
    {
        bulletTimer = Time.time;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = gameObject.GetComponent<EnemyHelper>().GetClosestEnemy(enemies);
        if (Time.time - bulletTimer > bulletCooldown && enemies.Length > 0)
        {
            //Turn Direction
            Vector3 targetDirection = closestEnemy.GetComponent<Transform>().position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z), Quaternion.identity);
            gameObject.GetComponent<Animator>().SetTrigger("attack");
            bulletTimer = Time.time;
        }
    }
}
