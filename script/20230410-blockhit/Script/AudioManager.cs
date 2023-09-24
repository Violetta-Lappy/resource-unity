using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum ENUM_MIXER_GROUP_NAME {
    MAIN,
    MUSIC,
    SFX,
    SFX_GAME,
    SFX_UI
}

public enum ENUM_AUDIO_MUSIC_TYPE {
    MAIN_MENU,
    MUSIC_001,
    MUSIC_002
}

public enum ENUM_AUDIO_SFX_GAME_TYPE {
    OBSTACLE_SUCCESS_PAINT,
    OBSTACLE_FAIL_PAINT,
    SAW_POWER_UP,
    HUB_CLICK
}

public enum ENUM_AUDIO_SFX_UI_TYPE {
    SELECT,
    HOVER
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonBlank<AudioManager> {
    public AudioMixerGroup[] sz_m_mixers;
    private AudioSource m_audioSourceMusic;

    public AudioClip[] sz_m_audioClipMusic;
    public AudioClip[] sz_m_audioClipSfxUI;
    public AudioClip[] sz_m_audioClipSfxGame;

    private void Start() {
        m_audioSourceMusic = this.GetComponent<AudioSource>();
        PlayMusic(); 
    }    

    public void PlayMusic(bool isLoop = true) {
        int id = Random.Range(0,2);

        m_audioSourceMusic = this.GetComponent<AudioSource>();

        m_audioSourceMusic.outputAudioMixerGroup = sz_m_mixers[(int)ENUM_MIXER_GROUP_NAME.MUSIC];
        m_audioSourceMusic.clip = sz_m_audioClipMusic[id];
        m_audioSourceMusic.loop = isLoop;
        m_audioSourceMusic.Play();
    }

    public void PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE type) {
        int id = (int)type;

        GameObject audioObject = CreateAudioObject();
        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = sz_m_mixers[(int)ENUM_MIXER_GROUP_NAME.SFX_UI];
        tempAudioSource.clip = sz_m_audioClipSfxUI[id];
        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject, tempAudioSource.clip.length));
    }

    public void PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE type) {
        int id = (int)type;

        GameObject audioObject = CreateAudioObject();
        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = sz_m_mixers[(int)ENUM_MIXER_GROUP_NAME.SFX_GAME];
        tempAudioSource.clip = sz_m_audioClipSfxGame[id];
        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject, tempAudioSource.clip.length));
    }

    /*EXTERNAL-FUNCTIONS*/
    private GameObject CreateAudioObject() {
        GameObject newGameObject = new GameObject();
        newGameObject.transform.parent = this.transform;

        newGameObject.AddComponent<AudioSource>();
        return newGameObject;
    }

    private IEnumerator DestroyAudioObject(GameObject gameObject, float timeToDestroy = 10.0f) {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
