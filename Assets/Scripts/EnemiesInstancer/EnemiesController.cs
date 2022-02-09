using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 enemyStartPosition;
    private List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> getEnemies()
    {
        return enemies;
    }

    private void Start()
    {
        enemies.Add(Instantiate(enemyPrefab, enemyStartPosition, Quaternion.identity));
    }
    void Update()
    {
        MoveEnemies();
    }

    void MoveEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.transform.position = new Vector3(enemy.transform.position.x - enemy.GetComponent<EnemyBehavior>().getMovmentSpeed(), enemy.transform.position.y, enemy.transform.position.z);
        }
    }
}
