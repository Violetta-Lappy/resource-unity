using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

namespace VLGameProject.VLVideo {
    public class VideoManager : Singleton<VideoManager> {
        public SOABSVideoItem m_videoItem;
        public RawImage m_rawImage;
        public VideoPlayer m_videoPlayer;

        public RawImage Get_RawImage() { return m_rawImage; }
        public VideoPlayer Get_VideoPlayer() { return m_videoPlayer; }

        void Start() {
            m_videoPlayer = this.GetComponent<VideoPlayer>();

#if UNITY_WEBGL
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "filename.mp4");
#endif

            StartCoroutine(RoutinePlayVideo());

            Get_VideoPlayer().loopPointReached += OnLoopPointReached;
        }

        /// <summary>
        /// Event execute when video end
        /// </summary>
        /// <param name="arg_source"></param>
        private void OnLoopPointReached(VideoPlayer arg_source) {
            BehaviorRemoveBackground();
        }

        public void PlayVideo(SOABSVideoItem arg_videoItem) {
            StartCoroutine(RoutinePlayVideo());
        }

        private IEnumerator RoutinePlayVideo() {
            Get_VideoPlayer().Prepare();

            while (Get_VideoPlayer().isPrepared == false) {
                yield return new WaitForSeconds(1.0f);
                break;
            }

            Get_RawImage().texture = Get_VideoPlayer().texture;

            Get_VideoPlayer().Play();
        }

        public void BehaviorRemoveBackground() {
            Get_RawImage().gameObject.SetActive(false);
        }
    }
}

