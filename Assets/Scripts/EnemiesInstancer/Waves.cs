using UnityEngine;
using System.Collections.Generic;

public class Waves : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;

    public List<(GameObject, float)> waves = new List<(GameObject, float)>();
    private int wavesSize;

    public int GetWavesSize()
    {
        return wavesSize;
    }

    private void Awake()
    {
        //Primeira Wave
        waves.Add((timer, 5));
        AddRepeated(enemy1, 5, 2);
        waves.Add((enemy2, 5));
        AddRepeated(enemy1, 4, 1);
        waves.Add((enemy2, 3));

        //Segunda Wave
        waves.Add((timer, 5));
        AddRepeated(enemy1, 5, 2);
        waves.Add((enemy2, 5));
        AddRepeated(enemy1, 4, 1);
        waves.Add((enemy2, 3));

        wavesSize = waves.ToArray().Length;
    }

    public void AddRepeated(GameObject enemy, float timeToSpawn, int count)
    {
        while(count > 0)
        {
            waves.Add((enemy, timeToSpawn));
            count--;
        }
    }
}
