using UnityEngine;
using System.Collections.Generic;

public class Waves : MonoBehaviour
{
    [SerializeField] GameObject timer;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject enemy4;
    [SerializeField] GameObject enemy5;

    public List<(GameObject, float)> waves = new List<(GameObject, float)>();
    private int wavesSize;

    public int GetWavesSize()
    {
        return wavesSize;
    }

    private void Awake()
    {
        //Primeira Wave
        waves.Add((timer, 30));
        AddRepeated(enemy1, 5, 10);
        waves.Add((enemy2, 3));
        AddRepeated(enemy1, 5, 3);
        waves.Add((enemy2, 3));
        AddRepeated(enemy1, 5, 3);
        waves.Add((enemy2, 3));
        AddRepeated(enemy1, 10, 2);
        waves.Add((enemy2, 3));

        //Segunda Wave
        waves.Add((timer, 30));
        AddRepeated(enemy2, 5, 10);
        waves.Add((enemy3, 3));
        AddRepeated(enemy2, 5, 3);
        waves.Add((enemy3, 3));
        AddRepeated(enemy2, 5, 3);
        waves.Add((enemy3, 3));
        AddRepeated(enemy2, 10, 2);
        waves.Add((enemy3, 3));

        //Terceira Wave
        waves.Add((timer, 30));
        AddRepeated(enemy3, 5, 10);
        waves.Add((enemy4, 3));
        AddRepeated(enemy3, 5, 3);
        waves.Add((enemy4, 3));
        AddRepeated(enemy3, 5, 3);
        waves.Add((enemy4, 3));
        AddRepeated(enemy3, 10, 2);
        waves.Add((enemy4, 3));

        //Quarta Wave
        waves.Add((timer, 30));
        AddRepeated(enemy4, 5, 10);
        waves.Add((enemy5, 3));
        AddRepeated(enemy4, 5, 3);
        waves.Add((enemy5, 3));
        AddRepeated(enemy4, 5, 3);
        waves.Add((enemy5, 3));
        AddRepeated(enemy4, 10, 2);
        waves.Add((enemy5, 3));

        //Quinta Wave
        waves.Add((timer, 30));
        AddRepeated(enemy5, 2, 30);

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
