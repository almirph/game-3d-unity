using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
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
            return true;
        }
        else if (!isDead)
        {
            health -= damage;
        }
        return false;
    }
}
