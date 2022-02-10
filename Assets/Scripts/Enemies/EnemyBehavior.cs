using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float movmentSpeed;
    [SerializeField] private int positionMovment;

    public int getPositionMovment()
    {
        return positionMovment;
    }
    public void setNextPositionMovment()
    {
        positionMovment ++;
    }


    private void Start()
    {
        positionMovment = 0;
    }

    public float getMovmentSpeed()
    {
        return movmentSpeed;
    }
}
