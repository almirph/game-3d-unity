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
            if(menu)
                Destroy(menu.gameObject);
            
            menu = Instantiate(menuPrefab);
            //Select tile all units
            menu.GetComponent<MenuBuyOptions>().createMage.selectedTile = this;
            menu.GetComponent<MenuBuyOptions>().createMage2.selectedTile = this;
            isSelected = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

    }

}
