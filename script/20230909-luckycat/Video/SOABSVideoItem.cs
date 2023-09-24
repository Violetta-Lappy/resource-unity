using UnityEngine;
using UnityEngine.Video;

namespace VLGameProject.VLVideo {
    public abstract class SOABSVideoItem : ScriptableObject {
        public float f_time;
        public VideoClip m_videoClip;
        public abstract void VideoItem_Prepare();
        public abstract void VideoItem_Event();
        public abstract void VideoItem_LoadSuccess();
    }

    [CreateAssetMenu(fileName = "New Example", menuName = "VLGameProject/VideoItem/Example")]
    public class VideoItemExample : SOABSVideoItem {
        public override void VideoItem_Event() {
            throw new System.NotImplementedException();
        }

        public override void VideoItem_LoadSuccess() {
            throw new System.NotImplementedException();
        }

        public override void VideoItem_Prepare() {
            Debug.Log($"Hello World Example from {nameof(VideoItemExample)}");
        }
    }

    [CreateAssetMenu(fileName = "New Blank", menuName = "VLGameProject/VideoItem/Blank")]
    public class VideoItemBlank : SOABSVideoItem {
        public override void VideoItem_Event() {
            throw new System.NotImplementedException();
        }

        public override void VideoItem_LoadSuccess() {
            throw new System.NotImplementedException();
        }

        public override void VideoItem_Prepare() {
            Debug.Log($"Hello World Example from {nameof(VideoItemBlank)}");
        }
    }
}

