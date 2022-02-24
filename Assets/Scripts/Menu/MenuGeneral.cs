using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGeneral : MonoBehaviour
{

    private float points;
    [SerializeField] private float coins;
    [SerializeField] private float health;
    [SerializeField] private Text pointText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text healthText;
    [SerializeField] private AudioClip healthSound;
    void Awake()
    {
        points = 0;
        pointText.text = "Points: " + points.ToString();
        healthText.text = "Health: " + health.ToString(); 
        coinText.text = "Coins: " + coins.ToString();
        print("Points: " + points.ToString());
        PointsEvent.current.onPointsTrigger += OnPointsTrigger;
        CoinsEvent.current.onCoinsTrigger += OnCoinsTrigger;
        PlayerHealthEvent.current.onPlayerHealthTrigger += OnHealthTrigger;
        CoinsEvent.current.onCoinsGetTrigger += GetCoins;
    }

    public float GetCoins()
    {
        return coins;
    }

    public void AddPoints(float pointsToAdd)
    {
        points += pointsToAdd;
        pointText.text = "Points: " + points.ToString();
    }

    public void AddCoins(float coinsToAdd)
    {
        coins += coinsToAdd;
        coinText.text = "Coins: " + coins.ToString();
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
        healthText.text = "Health: " + health.ToString();
        SoundEffect.current.PlayAudioClip(healthSound);
        if (health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnPointsTrigger(float pointsToAdd)
    {
        AddPoints(pointsToAdd);
    }

    private void OnCoinsTrigger(float coinsToAdd)
    {
        AddCoins(coinsToAdd);
    }

    private void OnHealthTrigger(int health)
    {
        AddHealth(health);
    }
}
