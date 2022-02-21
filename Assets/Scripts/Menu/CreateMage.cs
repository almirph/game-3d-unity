using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMage : MonoBehaviour
{
    [SerializeField] private GameObject magePrefab;
    [SerializeField] private int magePrice;
    [SerializeField] private float height;

    public void CreateNewMage()
    {
        GameObject selectedTile = SelectedTile();
        if (!selectedTile.GetComponent<TileBehavior>().tower)
        {
            selectedTile.GetComponent<TileBehavior>().tower = Instantiate(magePrefab, new Vector3(selectedTile.GetComponent<Transform>().position.x, height, selectedTile.GetComponent<Transform>().position.z), Quaternion.identity);
        }
    }

    private GameObject SelectedTile()
    {
        GameObject selectedTile = null;
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach(GameObject tile in tiles)
        {
            if (tile.GetComponent<TileBehavior>().isSelected)
            {
                selectedTile = tile;
                break;
            }
        }
        return selectedTile;
    }
}
