using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VLGameProject.VLAudio;

namespace VLGameProject.VLAudio {
    public enum ENUM_AUDIO_SFX_GUI {
        K_NONE = 0,
        K_TRANSITION,
        K_POINTER_SELECT,
        K_POINTER_HOVER,
        K_CONFIRM,
        K_CANCEL,
        K_BACK,
        K_GUI_DROPDOWN_OPEN,
        K_NOTIFICATION_OPEN,
        K_NOTIFICATION_CLOSE,
    }

    public enum ENUM_AUDIO_SFX_GAME {
        K_NONE = 0,
        GUN,
        HIT_IMPACT,
        ENEMY_DEATH,
        K_FOOTSTEP,
    }

    public enum ENUM_AUDIO_MUSIC {
        K_NONE = 0,
        MAIN_MENU,
        K_GAMEPLAY,
        K_GAMEOVER,
    }

    public enum ENUM_AUDIOMIXER {
        K_NONE = 0,
        K_GROUP_MASTER = 1,
        K_GROUP_FX_SEND,
        K_GROUP_FX_RECIEVE,
        K_GROUP_AMBIENCE,
        K_GROUP_ENVIROMENT,
        K_GROUP_MUSIC,
        K_GROUP_SFX,
        K_GROUP_VOCAL,
        K_GROUP_VOICE_COMMUNICATION,
        K_SUBGROUP_SFX_GUI,
        K_SUBGROUP_SFX_GAME,
        K_SUBGROUP_SFX_FOLEY,
        K_SUBGROUP_VOCAL_PLAYER,
    }

    public class AudioManager : MonoBehaviour {
        public const float K_AUDIO_RATE = 20.0f; //Default: 20.0f
        public const float K_AUDIO_RATE_MUTE = 80.0f; //Default: 80.0f    
        public static float Get_Value_AudioSlider_Default() { throw new System.NotImplementedException(); }

        public AudioClip Get_AudioClip_Music(ENUM_AUDIO_MUSIC _type) { throw new System.NotImplementedException(); }
        public AudioClip Get_AudioClip_SfxGame() { throw new System.NotImplementedException(); }
        public AudioClip Get_AudioClip_SfxGui() { throw new System.NotImplementedException(); }

        public void Play_Audio(AudioClip _audioClip) { }
        public void Play_Music(ENUM_AUDIO_MUSIC _type) {
            AudioPlayer player = new AudioPlayer()
                .Set_AudioClip(Get_AudioClip_Music(_type))
                .Set_Volume()
                .Set_Pitch()
                .Set_Pan();
            player.Play();
        }

        public void Play_Music(ENUM_AUDIO_MUSIC _type, float _volume, float _pitch, float _pan) {
            AudioPlayer player = new AudioPlayer()
                .Set_AudioClip(Get_AudioClip_Music(_type))
                .Set_Volume(_volume)
                .Set_Pitch(_pitch)
                .Set_Pan(_pan);
            player.Play();
        }
        public void Play_Effect(ENUM_AUDIO_MUSIC _type, float _volume, float _pitch) { }
        public void Play_Audio_Item(ENUM_AUDIO_MUSIC _type, float _volume, float _pitch) { }
    }
}
