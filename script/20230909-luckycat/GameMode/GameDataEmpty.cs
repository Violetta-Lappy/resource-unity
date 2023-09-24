using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataEmpty {

    public enum ENUM_GAMEDIFFICULTY {
        K_VERY_EASY,
        K_EASY,
        K_MEDIUM,
        K_HARD,
        K_VERY_HARD,
        K_NIGHTMARE,
        K_SANDBOX_TEST
    }

    private readonly Dictionary<ENUM_GAMEDIFFICULTY, string> dict_gameDifficultyName = new Dictionary<ENUM_GAMEDIFFICULTY, string>() {
        {ENUM_GAMEDIFFICULTY.K_VERY_EASY, "Very Easy"},
        {ENUM_GAMEDIFFICULTY.K_EASY, "Easy"},
    };

    public string str_helloMessage = $"Hello World !! Message coming from {typeof(GameDataEmpty).Name}.";

    /// <summary>
    /// Builder Class Design Pattern
    /// </summary>
    public GameDataEmpty() { }

    public string Get_HelloMessage() { return str_helloMessage; }
    public GameDataEmpty Set_HelloMessage(string _text) {
        str_helloMessage = _text;
        return this;
    }
}
