using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [Header("Video Players")]
    [SerializeField] private VideoPlayer startVideoPlayer; // Film 1
    [SerializeField] private VideoPlayer endVideoPlayer;   // Film 2

    [Header("Ustawienia czasu")]
    [SerializeField] private float skipDelay = 3.0f; // Czas w sekundach przed mo¿liwoœci¹ klikniêcia

    [Header("Nastêpna Scena")]
    [SerializeField] private string nextSceneName = "SampleScene";

    private bool isPlayingEnd = false;
    private float timer = 0f;

    void Start()
    {
        if (startVideoPlayer != null)
        {
            startVideoPlayer.gameObject.SetActive(true);
            startVideoPlayer.Play();
            startVideoPlayer.loopPointReached += OnStartVideoFinished;
        }

        if (endVideoPlayer != null)
        {
            endVideoPlayer.gameObject.SetActive(false);
            endVideoPlayer.loopPointReached += OnEndVideoFinished;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= skipDelay && !isPlayingEnd)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SwitchToEndVideo();
            }
        }
    }

    void SwitchToEndVideo()
    {
        if (isPlayingEnd) return;
        isPlayingEnd = true;

        // Natychmiast ukrywamy pierwszy odtwarzacz – w tym momencie pod spodem
        // idealnie widaæ nasz statyczny obraz z napisem, co maskuje wszelkie opóŸnienia!
        if (startVideoPlayer != null)
        {
            startVideoPlayer.Stop();
            startVideoPlayer.gameObject.SetActive(false);
        }

        // Uruchamiamy drugi film
        if (endVideoPlayer != null)
        {
            endVideoPlayer.gameObject.SetActive(true);
            endVideoPlayer.Play();
        }
    }

    void OnStartVideoFinished(VideoPlayer vp)
    {
        if (!isPlayingEnd)
        {
            SwitchToEndVideo();
        }
    }

    void OnEndVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}