using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletCooldown;
    private float bulletTimer;

    private void Start()
    {
        bulletTimer = Time.time;
    }

    void Update()
    {
        print(Time.time + "/" +  bulletTimer);
        if(Time.time - bulletTimer > bulletCooldown)
        {
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            bulletTimer = Time.time;
        }
    }
}
