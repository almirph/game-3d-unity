using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private float movmentSize;
    [SerializeField] private float scrollMovmentSize;
    void Update()
    {
        Movment();
    }

    void Movment()
    {
        //Arrow up and down
        if(Input.GetKey(KeyCode.DownArrow) && transform.position.z > 28)
        {
            transform.position =  new Vector3(transform.position.x, transform.position.y, transform.position.z - movmentSize);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 58)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movmentSize);
        }

        //Arrow left and right
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 37)
        {
            transform.position = new Vector3(transform.position.x - movmentSize, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 57)
        {
            transform.position = new Vector3(transform.position.x + movmentSize, transform.position.y, transform.position.z);
        }

        //Mouse scroll up and down
        if (Input.mouseScrollDelta.y > 0f && transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - scrollMovmentSize, transform.position.z);
        }

        if (Input.mouseScrollDelta.y < 0f && transform.position.y < 16)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + scrollMovmentSize, transform.position.z);
        }
    }
}
