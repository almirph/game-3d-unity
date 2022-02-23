using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private Vector3 enemyStartPosition;
    [SerializeField] private Vector3[] movmentPoints;
    private List<GameObject> enemies = new List<GameObject>();
    private float instanciateTimer;
    private int wavePosition;
    private List<(GameObject, float)> waves = new List<(GameObject, float)>();
    private int wavesSize;
    private GameObject actualTimer;

    private void Start()
    {
        wavePosition = 0;
        instanciateTimer = Time.time;
        waves = gameObject.GetComponent<Waves>().waves;
        wavesSize = gameObject.GetComponent<Waves>().GetWavesSize();

        //First time treatment
        TimerTreatment();
    }
    void Update()
    {
        if (wavePosition + 1 < wavesSize && Time.time - instanciateTimer > waves[wavePosition].Item2)
        {
            wavePosition++;
            instanciateTimer = Time.time;
            if (waves[wavePosition].Item1.tag == "Timer")
            {
                TimerTreatment();
            }
            else
            {
                if (actualTimer)
                {
                    Destroy(actualTimer.gameObject);
                }
                EnemyTreatment();
            }

        }
        MoveEnemies();
    }

    private void TimerTreatment()
    {
        actualTimer = Instantiate(waves[wavePosition].Item1);
        actualTimer.GetComponent<TimerController>().setTimer(waves[wavePosition].Item2);
        actualTimer.GetComponent<TimerController>().StartCountdown();
    }

    private void EnemyTreatment()
    {
        enemies.Add(Instantiate(waves[wavePosition].Item1, enemyStartPosition, Quaternion.identity));
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
                    enemy.transform.position = new Vector3(enemy.transform.position.x + (enemy.GetComponent<EnemyBehavior>().getMovmentSpeed()) * Mathf.Sign(nextPoint.x - enemy.transform.position.x), enemy.transform.position.y, enemy.transform.position.z);
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

    //Seta posição do array ou destroi objeto
    void setNextPoint(float xDiference, float zDiference, GameObject enemy, List<GameObject> destroiedEnemies)
    {

        if (enemy.GetComponent<EnemyBehavior>().getPositionMovment() == movmentPoints.Length - 1)
        {
            destroiedEnemies.Add(enemy);
            PlayerHealthEvent.current.PlayerHealthTrigger(-1);
            Destroy(enemy);
        }

        else if (enemy.GetComponent<EnemyBehavior>().getPositionMovment() < movmentPoints.Length)
        {
            enemy.GetComponent<EnemyBehavior>().setNextPositionMovment();
        }
    }
}
