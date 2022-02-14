using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("click");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
