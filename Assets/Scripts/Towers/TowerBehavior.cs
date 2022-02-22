using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private float bulletHeight;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float bulletRange;

    private float bulletTimer;

    private void Start()
    {
        bulletTimer = Time.time;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = gameObject.GetComponent<EnemyHelper>().GetClosestEnemy(enemies);
        if (Time.time - bulletTimer > bulletCooldown)
        {
            if (closestEnemy && VerifyDistance(closestEnemy))
            {
                gameObject.GetComponent<Animator>().SetTrigger("attack");
                GameObject newBullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y + bulletHeight, transform.position.z), Quaternion.identity);

                //Turn Direction
                Vector3 targetDirection = closestEnemy.GetComponent<Transform>().position - transform.position;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }

            else
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 1));
            }

            bulletTimer = Time.time;
        }

    }

    public bool VerifyDistance(GameObject closestEnemy)
    {
        if (!closestEnemy)
        {
            return false;
        }

        Vector3 enemyPosition = closestEnemy.GetComponent<Transform>().position;

        //Verify in X direction
        if (transform.position.x > enemyPosition.x && transform.position.x - enemyPosition.x > bulletRange)
        {
            return false;
        }
        else if (transform.position.x < enemyPosition.x && enemyPosition.x - transform.position.x > bulletRange)
        {
            return false;
        }

        //Verify in Z direction
        if (transform.position.z > enemyPosition.z && transform.position.z - enemyPosition.z > bulletRange)
        {
            return false;
        }
        else if (transform.position.z < enemyPosition.z && enemyPosition.z - transform.position.z > bulletRange)
        {
            return false;
        }

        return true;
    }
}
