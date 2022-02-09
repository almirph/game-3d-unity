using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCooldown;

    private void Start()
    {
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
