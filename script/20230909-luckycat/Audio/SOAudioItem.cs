using UnityEngine;

namespace VLGameProject.VLAudio {

    [System.Serializable]
    public class AudioItemSetting {
        public float f_volume;
        public float f_pitch;
        public float f_pan;
        public bool isRoundRobin;
    }

    public class SOAudioItem : ScriptableObject {
        public AudioItemSetting m_setting;
        public AudioClip m_audioClip;
        public AudioClip Get_AudioClip() { return m_audioClip; }
    }
}

