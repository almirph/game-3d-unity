using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float movmentSpeed;

    public float getMovmentSpeed()
    {
        return movmentSpeed;
    }
}
