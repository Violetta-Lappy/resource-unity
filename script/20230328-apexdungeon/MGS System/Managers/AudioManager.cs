using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using UnityEngine.Audio;

public class AudioManager : Singleton_Persist<AudioManager>
{    
    [Header("Mixer Sources")]
    public AudioMixerGroup[] mixerGroups;

    [Header("Audio Source")]
    public AudioSource audioSource_Music;

    [Header("Audio Stuff")]
    public AudioSoundSet[] soundArray_Music;
    public AudioSoundSet[] soundArraySFX_UI;    
    public AudioSoundSet[] soundArraySFX_GAME;    

    //-- SYSTEM --
    private void Start() 
    {
        
    }

    private void Update() 
    {
        
    }

    public void InitMixer()
    {
        SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_MasterVol);
        SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_MusicVol);
        SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFXVol);
        SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol);
        SetMixerVol(ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_GameVol);
    }

    public GameObject Create_AudioObject()
    {
        GameObject newGameObject = new GameObject();
        newGameObject.transform.parent = this.transform;

        newGameObject.AddComponent<AudioSource>();        
        return newGameObject;
    }
    
    //-- MUSIC PLAYING FUNCTIONS --
    public void PlayMusic(ENUM_AUDIO_MUSIC_TYPE musicType, bool isLoop = true)
    {
        int id = (int)musicType;

        audioSource_Music = this.GetComponent<AudioSource>();

        audioSource_Music.outputAudioMixerGroup = mixerGroups[(int)ENUM_MIXER_GROUP_NAME.Options_Mixer_MusicVol];
        
        audioSource_Music.clip = soundArray_Music[id].audioClip;
        audioSource_Music.volume = soundArray_Music[id].volume;
            
        if(soundArray_Music[id].pitch <= 1.0f)
        {
            audioSource_Music.pitch = 1.0f;        
        }

        else if(soundArray_Music[id].pitch > 1.0f)
        {
            audioSource_Music.pitch = soundArray_Music[id].pitch;
        }          

        audioSource_Music.loop = isLoop;        

        audioSource_Music.Play();                
    }    

    //-- SFX PLAYING FUNCTIONS --    
    public void PlaySFX_UI(ENUM_AUDIO_SFX_UI_TYPE sfxUIType)
    {
        int id = (int)sfxUIType;

        GameObject audioObject = Create_AudioObject();

        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = mixerGroups[(int)ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol];
        tempAudioSource.clip = soundArraySFX_UI[id].audioClip;
        tempAudioSource.volume = soundArraySFX_UI[id].volume;        

        if(soundArraySFX_UI[id].pitch <= 1.0f)
        {
            tempAudioSource.pitch = 1.0f;
        }

        else if(soundArraySFX_UI[id].pitch > 1.0f)
        {
            tempAudioSource.pitch = soundArraySFX_UI[(int)sfxUIType].pitch;
        }

        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject));
    }

    //Will remove in future
    public void PlaySFX_UI(int id)
    {        
        GameObject audioObject = Create_AudioObject();

        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = mixerGroups[(int)ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol];
        tempAudioSource.clip = soundArraySFX_UI[id].audioClip;
        tempAudioSource.volume = soundArraySFX_UI[id].volume;

        if (soundArraySFX_UI[id].pitch <= 1.0f)
        {
            tempAudioSource.pitch = 1.0f;
        }

        else if (soundArraySFX_UI[id].pitch > 1.0f)
        {
            tempAudioSource.pitch = soundArraySFX_UI[id].pitch;
        }

        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject));
    }

    public void PlaySFX_Game(ENUM_AUDIO_SFX_TYPE sfxGameType)
    {
        int id = (int)sfxGameType;

        GameObject audioObject = Create_AudioObject();

        AudioSource tempAudioSource = audioObject.GetComponent<AudioSource>();

        tempAudioSource.outputAudioMixerGroup = mixerGroups[(int)ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_GameVol];
        tempAudioSource.clip = soundArraySFX_GAME[id].audioClip;
        tempAudioSource.volume = soundArraySFX_GAME[id].volume;        

        if(soundArraySFX_GAME[id].pitch <= 1.0f)
        {
            tempAudioSource.pitch = 1.0f;
        }

        else if(soundArraySFX_GAME[id].pitch > 1.0f)
        {
            tempAudioSource.pitch = soundArraySFX_GAME[(int)sfxGameType].pitch;
        }

        tempAudioSource.Play();

        StartCoroutine(DestroyAudioObject(audioObject));
    }    

    public void SetMixerVol(ENUM_MIXER_GROUP_NAME mixerType)
    {
        AudioMixer mixer = mixerGroups[(int)mixerType].audioMixer;
        //string mixerName = System.Enum.GetName(typeof(ENUM_MIXER_GROUP_NAME), mixerType);
        string mixerName = mixerType.ToString();

        switch (mixerType)
        {
            case ENUM_MIXER_GROUP_NAME.Options_Mixer_MasterVol:

                mixer.SetFloat(mixerName, SaveDataMNG.Load_OptionsMixerMaster() == 0
                    ? -ProjectConstants.MGS_AUDIO_RATE_MUTE : Mathf.Log10(SaveDataMNG.Load_OptionsMixerMaster()) * ProjectConstants.MGS_AUDIO_RATE);
                break;

            case ENUM_MIXER_GROUP_NAME.Options_Mixer_MusicVol:

                mixer.SetFloat(mixerName, SaveDataMNG.Load_OptionsMixerMusic() == 0
                    ? -ProjectConstants.MGS_AUDIO_RATE_MUTE : Mathf.Log10(SaveDataMNG.Load_OptionsMixerMusic()) * ProjectConstants.MGS_AUDIO_RATE);
                break;

            case ENUM_MIXER_GROUP_NAME.Options_Mixer_SFXVol:

                mixer.SetFloat(mixerName, SaveDataMNG.Load_OptionsMixerSFX() == 0
                    ? -ProjectConstants.MGS_AUDIO_RATE_MUTE : Mathf.Log10(SaveDataMNG.Load_OptionsMixerSFX()) * ProjectConstants.MGS_AUDIO_RATE);
                break;

            case ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_UIVol:

                mixer.SetFloat(mixerName, SaveDataMNG.Load_OptionsMixerSFX_UI() == 0
                    ? -ProjectConstants.MGS_AUDIO_RATE_MUTE : Mathf.Log10(SaveDataMNG.Load_OptionsMixerSFX_UI()) * ProjectConstants.MGS_AUDIO_RATE);
                break;

            case ENUM_MIXER_GROUP_NAME.Options_Mixer_SFX_GameVol:

                mixer.SetFloat(mixerName, SaveDataMNG.Load_OptionsMixerSFX_Game() == 0
                    ? -ProjectConstants.MGS_AUDIO_RATE_MUTE : Mathf.Log10(SaveDataMNG.Load_OptionsMixerSFX_Game()) * ProjectConstants.MGS_AUDIO_RATE);
                break;
        }
    }    

    //-- TOOLS --

    public IEnumerator DestroyAudioObject(GameObject gameObject, float timeToDestroy = 10.0f)
    {
        yield return new WaitForSeconds(timeToDestroy);

        Destroy(gameObject);
    }
}
