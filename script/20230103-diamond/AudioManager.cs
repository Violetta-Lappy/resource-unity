/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: Audio Manager to manage all audio and route to respective mixer
 */

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
    MUSIC_001,
    MUSIC_002
}

public enum ENUM_AUDIO_SFX_GAME_TYPE {
    MOVE_DOWN,
    MATCH_COMPLETE
}

public enum ENUM_AUDIO_SFX_UI_TYPE {
    SELECT,
    HOVER
}

public class AudioManager : SingletonBlank<AudioManager> {
    public AudioMixerGroup[] m_sz_mixers;
    private AudioSource m_audioSourceMusic;

    public AudioClip[] m_sz_audioClipMusic;
    public AudioClip[] m_sz_audioClipSfxUI;
    public AudioClip[] m_sz_audioClipSfxGame;

    private void Start() {
        m_audioSourceMusic = this.GetComponent<AudioSource>();
        PlayMusic(); 
    }    

    public void PlayMusic(bool isLoop = true) {
        int id = Random.Range(0,2);

        m_audioSourceMusic = this.GetComponent<AudioSource>();

        m_audioSourceMusic.outputAudioMixerGroup = m_sz_mixers[(int)ENUM_MIXER_GROUP_NAME.MUSIC];
        m_audioSourceMusic.clip = m_sz_audioClipMusic[id];
        m_audioSourceMusic.loop = isLoop;
        m_audioSourceMusic.Play();
    }

    public void PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE type) {
        int id = (int)type;

        GameObject audioObject = CreateAudioObject();
        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = m_sz_mixers[(int)ENUM_MIXER_GROUP_NAME.SFX_UI];
        tempAudioSource.clip = m_sz_audioClipSfxUI[id];
        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject, tempAudioSource.clip.length));
    }

    public void PlaySFX_Game(ENUM_AUDIO_SFX_GAME_TYPE type) {
        int id = (int)type;

        GameObject audioObject = CreateAudioObject();
        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = m_sz_mixers[(int)ENUM_MIXER_GROUP_NAME.SFX_GAME];
        tempAudioSource.clip = m_sz_audioClipSfxGame[id];
        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject, tempAudioSource.clip.length));
    }

    /*EXTERNAL-FUNCTIONS*/
    public GameObject CreateAudioObject() {
        GameObject newGameObject = new GameObject();
        newGameObject.transform.parent = this.transform;

        newGameObject.AddComponent<AudioSource>();
        return newGameObject;
    }

    public IEnumerator DestroyAudioObject(GameObject gameObject, float timeToDestroy = 10.0f) {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
