using System.Collections;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    [Header("References")]
    public AudioSource audioSource;

    [Header("Fade Settings")]
    public float fadeDuration = 2.0f;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource.clip != null)
        {
            float randomStartTime = Random.Range(0f, audioSource.clip.length);
            audioSource.time = randomStartTime;

            audioSource.volume = 0f;
            audioSource.Play();

            StartCoroutine(FadeInMusic());
        }
        else
        {
            Debug.LogWarning("No Audio Clip assigned to the Audio Source!", this);
        }
    }

    IEnumerator FadeInMusic()
    {
        float targetVolume = 1.0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}