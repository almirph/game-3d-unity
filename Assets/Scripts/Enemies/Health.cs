using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int health;
    [SerializeField] private float pointsToAdd;
    [SerializeField] private float coinsToAdd;

    public int GetHealth()
    {
        return health;
    } 
    private bool isDead { get; set; }

    private void Start()
    {
        isDead = false;
    }

    public bool TakeDamage(int damage)
    {
        if(health - damage <= 0)
        {
            isDead = true;
            Destroy(gameObject);
            PointsEvent.current.PointsTrigger(pointsToAdd);
            CoinsEvent.current.CoinsTrigger(coinsToAdd);
            return true;
        }
        else if (!isDead)
        {
            health -= damage;
        }
        return false;
    }
}
