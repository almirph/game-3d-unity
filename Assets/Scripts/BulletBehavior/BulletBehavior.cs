using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    private GameObject closestEnemy; 

    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            closestEnemy = gameObject.GetComponent<EnemyHelper>().GetClosestEnemy(enemies);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if(enemy.tag == "Enemy" && enemy == closestEnemy.GetComponent<Collider>())
        {
            closestEnemy.GetComponent<Health>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!closestEnemy)
        {
            Destroy(gameObject);
        }
        else
        {
            MoveToEnemy();

        }
    }

    private void MoveToEnemy()
    {
        
        Vector3 enemyPosition = closestEnemy.GetComponent<Transform>().position;

        //Move in X direction
        if(transform.position.x > enemyPosition.x)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x - bulletSpeed, transform.position.y, transform.position.z), transform.rotation);
        }
        else if (transform.position.x < enemyPosition.x)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x + bulletSpeed, transform.position.y, transform.position.z), transform.rotation);
        }

        //Move in Y direction
        if (transform.position.y > enemyPosition.y)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y - bulletSpeed, transform.position.z), transform.rotation);
        }
        else if (transform.position.y < enemyPosition.y)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + bulletSpeed, transform.position.z), transform.rotation);
        }

        //Move in Z direction
        if (transform.position.z > enemyPosition.z)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z - bulletSpeed), transform.rotation);
        }
        else if (transform.position.z < enemyPosition.z)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z + bulletSpeed), transform.rotation);
        }

    }

}
