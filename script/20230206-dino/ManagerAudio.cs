using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum ENUM_MIXER_GROUP_NAME
{
    MASTER,
    MUSIC,
    SFX,
    SFX_GAME,
    SFX_UI
}

public class ManagerAudio : SingletonBlank<ManagerAudio>
{
    public AudioMixerGroup[] m_mixerGroup;

    [System.Serializable]
    public class GameAudio
    {
        public string name;
        public AudioClip clip;
    }

    public GameAudio[] sz_BGM_Audio;
    public GameAudio[] sz_SFX_GAME_Audio;
    public GameAudio[] sz_SFX_GUI_Audio;

    [SerializeField] private AudioSource m_bgmSource;
    [SerializeField] private AudioSource m_sfxGameSource;
    [SerializeField] private AudioSource m_sfxGUISource;

    private bool isFadingOut = false;
    private bool isFadingIn = false;

    public AudioClip GetMusic(string name)
    {
        foreach (GameAudio audio in sz_BGM_Audio)
        {
            if (audio.name == name)
            {
                return audio.clip;
            }
        }

        return null;
    }

    public AudioClip GetGameSFX(string name)
    {
        foreach (GameAudio audio in sz_SFX_GAME_Audio)
        {
            if (audio.name == name)
            {
                return audio.clip;
            }
        }

        return null;
    }

    public AudioClip GetGUISFX(string name)
    {
        foreach (GameAudio audio in sz_SFX_GUI_Audio)
        {
            if (audio.name == name)
            {
                return audio.clip;
            }
        }

        return null;
    }

    public void PlayMusic(AudioClip clip, bool isLooping)
    {
        if (clip != null)
        {
            m_bgmSource.clip = clip;
            m_bgmSource.loop = isLooping;
            m_bgmSource.Play();
        }
        else
        {
            Debug.Log(this.name + ": Music clip not found!");
        }
    }

    public void PlayMusic(string audioName, bool isLooping) { if (GetMusic(audioName) != null) PlayMusic(GetMusic(audioName), isLooping); else Debug.Log(this.name + ": Music clip not found!"); }

    public void PlayGameSFX(AudioClip clip)
    {
        if (clip != null)
        {
            m_sfxGameSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log(this.name + ": Game SFX not found!");
        }
    }

    public void PlayGameSFX(string audioName) { if (GetGameSFX(audioName) != null) PlayGameSFX(GetGameSFX(audioName)); else Debug.Log(this.name + ": GameSFX not found!"); }

    public void PlayGUISFX(AudioClip clip)
    {
        if (clip != null)
        {
            m_sfxGUISource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log(this.name + ": GUI SFX not found!");
        }
    }

    public void PlayGUISFX(string audioName) { if (GetGUISFX(audioName) != null) PlayGUISFX(GetGUISFX(audioName)); else Debug.Log(this.name + ": GUI SFX not found!"); }

    public void MusicFadeOut(float fadeTime) { if (isFadingOut == false) StartCoroutine(MusicFadeOutRoutine(fadeTime)); else Debug.Log(this.name + ": Already fading out!"); }

    IEnumerator MusicFadeOutRoutine(float fadeTime)
    {
        float elapsedTime = 0f;

        isFadingOut = true;

        while (isFadingOut)
        {
            if (m_bgmSource.volume <= 0.01f)
            {
                m_bgmSource.volume = 0f;
                isFadingOut = false;
                break;
            }

            elapsedTime += Time.unscaledDeltaTime;

            float t = elapsedTime / fadeTime;

            yield return null;

            m_bgmSource.volume = Mathf.Lerp(1, 0, t);
        }
    }

    public void MusicFadeIn(float fadeTime, bool isForced) { if (isFadingIn == false) StartCoroutine(MusicFadeInRoutine(fadeTime, isForced)); else Debug.Log(this.name + ": Already fading in!"); }

    IEnumerator MusicFadeInRoutine(float fadeTime, bool isForced)
    {
        float elapsedTime = 0f;

        if (isForced) m_bgmSource.volume = 0;

        isFadingIn = true;

        while (isFadingIn)
        {
            if (m_bgmSource.volume >= 0.99f)
            {
                m_bgmSource.volume = 1f;
                isFadingIn = false;
                break;
            }

            elapsedTime += Time.unscaledDeltaTime;

            float t = elapsedTime / fadeTime;

            yield return null;

            m_bgmSource.volume = Mathf.Lerp(0, 1, t);
        }
    }

    /*
    public void SetMixerVol(ENUM_MIXER_GROUP_NAME mixerType)
    {
        AudioMixer mixer = m_mixerGroup[(int)mixerType].audioMixer;

        string mixerName = mixerType.ToString();

        switch (mixerType)
        {
            case ENUM_MIXER_GROUP_NAME.MASTER:
                mixer.SetFloat(mixerName, SaveData.Load_MixerMaster() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerMaster()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.MUSIC:
                    mixer.SetFloat(mixerName, SaveData.Load_MixerMusic() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerMusic()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.SFX:
                    mixer.SetFloat(mixerName, SaveData.Load_MixerSFX() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerSFX()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.SFX_GAME:
                    mixer.SetFloat(mixerName, SaveData.Load_MixerGameSFX() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerGameSFX()) * ProjectConstants.K_AUDIORATE);
                break;
            case ENUM_MIXER_GROUP_NAME.SFX_UI:
                        mixer.SetFloat(mixerName, SaveData.Load_MixerGUISFX() == 0
                    ? -ProjectConstants.K_AUDIO_RATE_MUTE : Mafthf.Log10(SaveData.Load_MixerGUISFX()) * ProjectConstants.K_AUDIORATE);
                break;
        }
    }
    */
}
