using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLAudio {    
    public class AudioPlayer : MonoBehaviour {
        //Variable
        public AudioSource m_audioSource;
        float f_destroyTime;

        public AudioSource Get_AudioSource() { return m_audioSource; }
        public float Get_Volume() { return Get_AudioSource().volume; }
        public float Get_Pitch() { return Get_AudioSource().pitch; }
        public float Get_Pan() { return Get_AudioSource().panStereo; }

        //Constructor
        public AudioPlayer() { }
        private void Start() {
            m_audioSource = GetComponent<AudioSource>();
        }

        //Function
        public void Play() => m_audioSource.Play();
        public AudioPlayer Set_AudioSource() {
            return this;
        }
        public AudioPlayer Set_AudioClip(AudioClip _audioClip) {
            Get_AudioSource().clip = _audioClip;
            return this;
        }
        public AudioPlayer Set_Priority(int _priority) {
            Get_AudioSource().priority = Mathf.Clamp(_priority, 0, 1);
            return this;
        }
        public AudioPlayer Set_Volume(float _volume = 1.0f) {
            Get_AudioSource().volume = Mathf.Clamp(_volume, 0, 1);
            return this;
        }
        public AudioPlayer Set_Pitch(float _pitch = 1.0f) {
            Get_AudioSource().pitch = Mathf.Clamp(_pitch, -3, 3);
            return this;
        }
        public AudioPlayer Set_Pan(float _pan = 0.0f) {
            Get_AudioSource().panStereo = Mathf.Clamp(_pan, -1, 1);
            return this;
        }
    }
}

