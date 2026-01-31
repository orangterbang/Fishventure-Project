using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        BubbleScene.Instance.StartTransition("Base Scene");
    }

    public void HowToPlay()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
