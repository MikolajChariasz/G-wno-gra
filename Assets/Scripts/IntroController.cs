using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [Header("References")]
    public VideoPlayer videoPlayer;

    [Header("Settings")]
    public string nextSceneName = "MainMenu";
    public float skipDelay = 3f;
    public double skipTargetTime = 18.0;

    private bool hasSkipped = false;
    private float timer = 0f;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= skipDelay && !hasSkipped && Input.GetMouseButtonDown(0))
        {
            SkipToEndAnimation();
        }
    }

    void SkipToEndAnimation()
    {
        hasSkipped = true;
        videoPlayer.time = skipTargetTime;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}