using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsEvent : MonoBehaviour
{
    public static PointsEvent current;

    private void Awake()
    {
        current = this;
    }

    public event Action<float> onPointsTrigger;
    public void PointsTrigger(float pointsToAdd)
    {
        onPointsTrigger(pointsToAdd);
    }
}
