/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: Manage all type of game value resources
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCurrencySettings {
    public const float K_VALUE_HIGHSCORE = 50.0f;
    public const float K_VALUE_MOVE = 1.0f;
    public const float K_VALUE_TIMER = 1.0f;
}

public enum ENUM_CURRENCY_TYPE {
    HIGH_SCORE,
    MOVE,
    TIMER
}

public class ManagerCurrency : SingletonBlank<ManagerCurrency> {

    /*VARIABLES*/
    public float _highScore, _move, _timer;

    public float F_highScore {
        get { return _highScore; }
        set {
            _highScore = (int)value;
            GUIManager.Instance.DoGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.HIGHSCORE, _highScore.ToString());
        }
    }

    public float F_move {
        get { return _move; }
        set {
            _move = (int)value;
            GUIManager.Instance.DoGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.MOVES, _move.ToString());
        }
    }

    public float F_timer {
        get { return _timer; }
        set {
            _timer = (int)value;
            GUIManager.Instance.DoGUIElementText(ENUM_GUIELEMENT_TEXT_TYPE.TIMER, _timer.ToString());
        }
    }

    /*PROCESSORS*/
    private void Start() {
        InvokeRepeating(nameof(IncreaseTimer), 1.0f, 1.0f);
    }

    /*FUNCTIONS*/

    public void IncreaseCurrency(ENUM_CURRENCY_TYPE type, float inputValue) {
        CalcCurrency(type, Mathf.Abs(inputValue));
    }

    public void DecreaseCurrency(ENUM_CURRENCY_TYPE type, float inputValue) {
        CalcCurrency(type, -1 * Mathf.Abs(inputValue));
    }

    public void CalcCurrency(ENUM_CURRENCY_TYPE type, float inputValue) {
        switch (type) {
            case ENUM_CURRENCY_TYPE.HIGH_SCORE: F_highScore += inputValue; break;
            case ENUM_CURRENCY_TYPE.MOVE: F_move += inputValue; break;
            case ENUM_CURRENCY_TYPE.TIMER: F_timer += inputValue; break;
            default: break;
        }
    }

    /*EXTERNAL-FUNCTIONS*/
    private void IncreaseTimer() {
        IncreaseCurrency(ENUM_CURRENCY_TYPE.TIMER, ManagerCurrencySettings.K_VALUE_TIMER);
    }
}
