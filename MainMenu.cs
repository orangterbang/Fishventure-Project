using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Che Wan Scene");
    }

    public void HowToPlay()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
