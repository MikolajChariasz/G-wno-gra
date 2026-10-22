using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    [Header("Video Player")]
    [SerializeField] private VideoPlayer videoPlayer;

    [Header("Filmy")]
    [SerializeField] private VideoClip introStartClip; // Film 1 (Pojawianie siê + napis)
    [SerializeField] private VideoClip introEndClip;   // Film 2 (Znikanie)

    [Header("Ustawienia czasu")]
    [SerializeField] private float skipDelay = 3.0f; // Czas w sekundach, po którym gracz mo¿e klikn¹æ

    [Header("Nastêpna Scena")]
    [SerializeField] private string nextSceneName = "SampleScene"; // Nazwa docelowej sceny gry

    private bool isPlayingEndClip = false;
    private float timer = 0f;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Konfiguracja i start pierwszego filmu
        videoPlayer.clip = introStartClip;
        videoPlayer.isLooping = false;
        videoPlayer.Play();

        // Nas³uchiwanie koñca odtwarzania dowolnego filmu
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Sprawdzanie czy minê³y 3 sekundy i czy gracz klikn¹³ myszk¹, a drugi film jeszcze siê nie zacz¹³
        if (timer >= skipDelay && !isPlayingEndClip)
        {
            if (Input.GetMouseButtonDown(0)) // Lewy przycisk myszy
            {
                PlayEndClip();
            }
        }
    }

    void PlayEndClip()
    {
        isPlayingEndClip = true;
        videoPlayer.clip = introEndClip;
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if (!isPlayingEndClip)
        {
            // Jeœli pierwszy film dobieg³ koñca naturalnie, a gracz nie klikn¹³, odtwarzamy film koñcowy
            PlayEndClip();
        }
        else
        {
            // Jeœli film koñcowy równie¿ siê skoñczy³, przechodzimy do w³aœciwej gry
            SceneManager.LoadScene(nextSceneName);
        }
    }
}