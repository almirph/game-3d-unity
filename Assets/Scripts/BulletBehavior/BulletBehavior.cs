using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private GameObject closestEnemy; 

    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length > 0)
        {
            GetClosestEnemy(enemies);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if(enemy.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        MoveToEnemy();
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

    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        print(enemies);
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.GetComponent<Transform>().transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        closestEnemy = bestTarget;
        return bestTarget;
    }
}
