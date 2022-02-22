using UnityEngine;
using UnityEngine.UI;

public class CreateMage : MonoBehaviour
{
    [SerializeField] private GameObject magePrefab;
    [SerializeField] private int magePrice;
    [SerializeField] private float height;
    public TileBehavior selectedTile;

    private void Start()
    {
        verifyButton();
    }

    private void Update()
    {
        verifyButton();
    }

    private void verifyButton()
    {
        if (gameObject.GetComponent<Button>().interactable && (CoinsEvent.current.onCoinsGetTrigger() < magePrice || selectedTile.tower))
        {
            gameObject.GetComponent<Button>().interactable = false;

        }
        else if (CoinsEvent.current.onCoinsGetTrigger() >= magePrice && !selectedTile.tower && !gameObject.GetComponent<Button>().interactable)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
    public void CreateNewMage()
    {
        if (CoinsEvent.current.onCoinsGetTrigger() >= magePrice)
        {
            if (!selectedTile.tower)
            {
                CoinsEvent.current.onCoinsTrigger(-magePrice);
                selectedTile.GetComponent<TileBehavior>().tower = Instantiate(magePrefab, new Vector3(selectedTile.GetComponent<Transform>().position.x, height, selectedTile.GetComponent<Transform>().position.z), Quaternion.identity);
            }
        }
    }

}
