using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExtension : MonoBehaviour
{            
    void Start()
    {        
        
    }
    
    void Update()
    {
        
    }

    public void PlaySound_FootStep()
    {
        AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_TYPE.FOOTSTEP);
    }

    public void PlaySound_Gun()
    {
        AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_TYPE.GUN);
    }
}
