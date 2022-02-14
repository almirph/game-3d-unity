using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 enemyStartPosition;
    [SerializeField] private Vector3[] movmentPoints;
    private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float instanciateCooldown;
    private float instanciateTimer;

    private void Start()
    {
        instanciateTimer = Time.time;
    }
    void Update()
    {
        if (Time.time - instanciateTimer > instanciateCooldown)
        {
            enemies.Add(Instantiate(enemyPrefab, enemyStartPosition, Quaternion.identity));
            instanciateTimer = Time.time;
        }
        MoveEnemies();
    }
    public List<GameObject> getEnemies()
    {
        return enemies;
    }


    void MoveEnemies()
    {
        List<GameObject> destroiedEnemies = new List<GameObject>();
        foreach (GameObject enemy in enemies)
        {
            if (!enemy)
            {
                destroiedEnemies.Add(enemy);
            }
            else
            {
                Vector3 nextPoint = movmentPoints[enemy.GetComponent<EnemyBehavior>().getPositionMovment()];
                float xDiference = Mathf.Abs(enemy.transform.position.x - nextPoint.x);
                float zDiference = Mathf.Abs(enemy.transform.position.z - nextPoint.z);

                if (xDiference < 0.01f && zDiference < 0.01)
                {
                    setNextPoint(xDiference, zDiference, enemy, destroiedEnemies);
                } 

                if (xDiference > 0.01f)
                {
                    enemy.transform.position = new Vector3(enemy.transform.position.x  + (enemy.GetComponent<EnemyBehavior>().getMovmentSpeed()) * Mathf.Sign(nextPoint.x - enemy.transform.position.x), enemy.transform.position.y, enemy.transform.position.z);
                }

                if (zDiference > 0.01f)
                {
                    enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + (enemy.GetComponent<EnemyBehavior>().getMovmentSpeed()) * Mathf.Sign(nextPoint.z - enemy.transform.position.z));
                }
            }
            

        }
        removeFromEnemies(destroiedEnemies);
    }

    void removeFromEnemies(List<GameObject> destroiedEnemies)
    {
        foreach (GameObject enemyDestroyed in destroiedEnemies)
        {
            enemies.Remove(enemyDestroyed);
        }
    }

    //Set array positon or destroy object
    void setNextPoint(float xDiference, float zDiference, GameObject enemy, List<GameObject> destroiedEnemies)
    {
        
        if ( enemy.GetComponent<EnemyBehavior>().getPositionMovment() == movmentPoints.Length - 1)
        {
            destroiedEnemies.Add(enemy);
            Destroy(enemy);
        }

        else if (enemy.GetComponent<EnemyBehavior>().getPositionMovment() < movmentPoints.Length)
        {
            enemy.GetComponent<EnemyBehavior>().setNextPositionMovment();
        }
    }
}
