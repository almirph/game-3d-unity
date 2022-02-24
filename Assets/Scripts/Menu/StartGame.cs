using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioClip playSound; 
    public void BtnStartGame()
    {
        print(playSound);
        SoundEffect.current.PlayAudioClip(playSound);
        SceneManager.LoadScene(0);
    }
}
