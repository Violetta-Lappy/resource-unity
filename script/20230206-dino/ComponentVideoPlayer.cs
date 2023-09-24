using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ComponentVideoPlayer : MonoBehaviour
{
    public RawImage m_rawImage;
    public VideoPlayer m_videoPlayer;

    void Start()
    {
        m_videoPlayer = this.GetComponent<VideoPlayer>();

#if UNITY_WEBGL
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "real gamer splashscreen.mp4");
#endif

        StartCoroutine(PlayVideo());

        //Link up with another function and execute when that video end
        m_videoPlayer.loopPointReached += OnLoopPointReached;
    }

    private void OnLoopPointReached(VideoPlayer source)
    {
        RemoveBackground();
    }

    IEnumerator PlayVideo()
    {
        m_videoPlayer.Prepare();

        while (!m_videoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(1.0f);
            break;
        }

        m_rawImage.texture = m_videoPlayer.texture;
        m_videoPlayer.Play();
    }

    void RemoveBackground()
    {
        m_rawImage.gameObject.SetActive(false);

        //Load to the next scene
        SceneManager.LoadScene(1);
    }
}