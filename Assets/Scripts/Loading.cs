using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += FilmZakonczony;
    }

    void FilmZakonczony(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneChange.wybranaScena);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
