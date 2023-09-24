using UnityEngine;
using VLGameProject.VLGameProgram;

[System.Serializable]
public class GameDataLuckyCat {
    public BetterEnumCollectibleEarnRate m_collectibleEarnRateType;
    
    [Header("Time")]
    public ProgramValueElement m_timeCountdown = new ProgramValueElement(0, 0, 0, 300, 0, 300);
    public ProgramValue m_coinEarn = new ProgramValue(0, 0, 0, 300, 0, 300);

    [Header("Collectible")]
    public ProgramValueElement m_earnRate = new ProgramValueElement(0, 0, 0, 3, 0, 3);    

    [Header("Player")]
    public Vector3 vec3_playerStartPos; //not-needed-i-guess
    public ProgramValueElement f_playerLife = new ProgramValueElement(0, 0, 0, 3, 0, 3);

    [Header("Enemy")]
    public ProgramValueElement f_requireNumOfEnemyDefeat = new ProgramValueElement(0, 0, 0, 100, 0, 100);    

    /// <summary>
    /// Builder Class Design Pattern
    /// </summary>
    public GameDataLuckyCat() { }

    public void Build_To_GameProgramValueManager(GameProgramManager arg_gameProgram) {
        //Announce these value towards GameValueManager
        arg_gameProgram.Get_GameValueManager()
            .Set_TimeCountdown(GetValue_TimeCountdown())
            .Set_PlayerLife(GetValue_PlayerLife());
    }

    public float GetValue_TimeCountdown() { return m_timeCountdown.Get_Value(); }
    public float GetValue_PlayerLife() { return f_playerLife.Get_Value(); }

    public static int Get_Value_CollectibleRate(ENUM_COLLECTIBLE_TYPE arg_type) {
        switch (arg_type) {
            case ENUM_COLLECTIBLE_TYPE.K_COIN_COPPER:
                return 5;
            case ENUM_COLLECTIBLE_TYPE.K_COIN_SILVER:
                return 10;
            case ENUM_COLLECTIBLE_TYPE.K_COIN_GOLD:
                return 15;
            case ENUM_COLLECTIBLE_TYPE.K_DIAMOND_GREEN:
                return 50;
            case ENUM_COLLECTIBLE_TYPE.K_DIAMOND_BLUE:
                return 75;
            case ENUM_COLLECTIBLE_TYPE.K_DIAMOND_RED:
                return 100;
            case ENUM_COLLECTIBLE_TYPE.K_CLOCK_SMALL:
                return 30;
            case ENUM_COLLECTIBLE_TYPE.K_CLOCK_LARGE:
                return 60;
            default:
                return 0;
        }
    }

    public GameDataLuckyCat Set_Value_TimeCountdown(float arg_value) {
        m_timeCountdown.Set_Value(arg_value);
        return this;
    }

    public GameDataLuckyCat Set_Value_PlayerLife(float arg_value) {
        f_playerLife.Set_Value(arg_value);
        return this;
    }

    public GameDataLuckyCat Set_Value_CoinEarn(float arg_value) {
        m_coinEarn.Set_Value(arg_value);
        return this;
    }
}
