using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BubbleScene : MonoBehaviour
{
    public static BubbleScene Instance;

    [Header("Assign the VideoPlayer on THIS object")]
    public VideoPlayer videoPlayer;

    [Header("Optional: assign the RawImage GameObject (same object is fine)")]
    public GameObject transitionRoot;

    private string nextSceneName;
    private bool isTransitioning = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (transitionRoot == null) transitionRoot = gameObject;
        transitionRoot.SetActive(false);
    }

    public void StartTransition(string sceneName)
    {
        if (isTransitioning) return;
        isTransitioning = true;

        // IMPORTANT: if you paused the game, unpause so UI/video behaves normally
        Time.timeScale = 1f;

        nextSceneName = sceneName;

        transitionRoot.SetActive(true);

        if (videoPlayer == null)
        {
            Debug.LogError("BubbleScene: VideoPlayer is not assigned!");
            isTransitioning = false;
            return;
        }

        videoPlayer.loopPointReached -= OnVideoFinished;
        videoPlayer.loopPointReached += OnVideoFinished;

        videoPlayer.Stop();
        videoPlayer.time = 0;
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoFinished;

        SceneManager.LoadScene(nextSceneName);

        // Hide after switching scene
        transitionRoot.SetActive(false);
        isTransitioning = false;
    }
}
