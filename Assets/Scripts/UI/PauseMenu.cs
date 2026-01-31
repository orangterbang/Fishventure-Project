using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Menu()
    {   
        SceneManager.LoadScene("menu ui");
        Time.timeScale = 1f;
        
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);

        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Use bubble transition if available
        if (BubbleScene.Instance != null)
            BubbleScene.Instance.StartTransition(SceneManager.GetActiveScene().name); // or use scene name
        else
            SceneManager.LoadScene(currentIndex);
    }
}
