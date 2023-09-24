using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectConstants : SingletonBlank<ProjectConstants>
{
    //ManagerGame consts
    public const int K_INITIALGAMESPEED = 5;
    public const float K_GAMESPEED_INCREMENT = 0.2f;

    //ManagerAudio consts
    public const float K_AUDIO_RATE = 20f;
    public const float K_AUDIO_RATE_MUTE = 80f;
    public static readonly float[] K_AUDIO_SLIDER_RANGE = { 0f, 1f, 0.5f}; //{min, max, default}
    public const float K_MUSIC_FADE_IN_TIME = 2f;
    public const float K_MUSIC_FADE_OUT_TIME = 2f;

    //ComponentMovement consts
    public const float K_DINO_JUMPFORCE = 6.5f;
    public const float K_DINO_GRAVITY = 20f;
    public const int K_DINO_HELD_JUMP_MULTIPLIER = 2;

    //FactoryObstacles consts
    public static readonly float[] K_SPAWNRATE_RANGE = { 0.5f, 2f }; //{min, max}

    //misc
    public const bool K_IS_ALLOW_FEATURE_COLORBLIND = false;


}
