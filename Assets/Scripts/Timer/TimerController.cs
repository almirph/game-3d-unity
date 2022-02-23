using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Text timerText;
    public float timeRemaining = 10;
    private bool startedCountdown;
    void Update()
    {
        if (timeRemaining > 0 && startedCountdown)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Next Wave in " + ((int)timeRemaining).ToString();
        }
    }

    public void setTimer(float timeToCount)
    {
        timeRemaining = timeToCount;
    }

    public void StartCountdown()
    {
        startedCountdown = true;
    }

}
