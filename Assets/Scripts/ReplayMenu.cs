using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{
    [SerializeField] GameObject replayMenu;
    bool gameEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        replayMenu.SetActive(false);
    }

    void Update()
    {
        if (gameEnd)
        {
            replayMenu.SetActive(true);
        }
        else
        {
            replayMenu.SetActive(false);
        }
    }

    void OnEnable()
    {
        GameManager.OnGameLose += SetReplayUI;
    }
    void OnDisable()
    {
        GameManager.OnGameLose -= SetReplayUI;
    }

    void SetReplayUI()
    {
        gameEnd = true;
        Time.timeScale = 0;
    }

    public void Menu()
    {   
        SceneManager.LoadScene("menu ui");
        Time.timeScale = 1;
    }

    public void Replay()
    {
        gameEnd = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
