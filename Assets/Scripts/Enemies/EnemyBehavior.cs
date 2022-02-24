using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float movmentSpeed;
    [SerializeField] private int positionMovment;
    private Health health;

    private void Start()
    {
        health = gameObject.GetComponent<Health>();
        positionMovment = 0;

    }

    private void Update()
    {
        Material material = gameObject.GetComponent<Renderer>().material;
        if (health.GetHealth() > 0 && health.GetHealth() < 10)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            material.SetColor("_Color" , Color.green);
        }

        if (health.GetHealth() >= 10 && health.GetHealth() < 20)
        {
            gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            material.SetColor("_Color", Color.blue);
        }

        if (health.GetHealth() >= 20 && health.GetHealth() < 30)
        {
            gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            material.SetColor("_Color", Color.yellow);
        }

        if (health.GetHealth() >= 30 && health.GetHealth() < 35)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            material.SetColor("_Color", Color.white);
        }

        if (health.GetHealth() >= 35)
        {
            gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
            material.SetColor("_Color", Color.black);
        }
    }

    public int getPositionMovment()
    {
        return positionMovment;
    }
    public void setNextPositionMovment()
    {
        positionMovment ++;
    }

    public float getMovmentSpeed()
    {
        return movmentSpeed;
    }
}
