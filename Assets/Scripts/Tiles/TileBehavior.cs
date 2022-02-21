using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileBehavior : MonoBehaviour
{
    [SerializeField] private Canvas menuPrefab;
    private static Canvas menu { get; set; }
    public bool isSelected;
    public GameObject tower;

    private void Start()
    {
        isSelected = false;
    }
    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<Renderer>().material.color = Color.white;
                tile.GetComponent<TileBehavior>().isSelected = false;
            }
            if(!menu)
            {
                menu = Instantiate(menuPrefab);
            }
        
            isSelected = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        
    }

}
