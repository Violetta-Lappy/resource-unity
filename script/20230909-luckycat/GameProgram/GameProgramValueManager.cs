/*
* Copyright (C) 2023 HOANGLONGPLANNER
*
* Licensed under the Apache License, Version 2.0(the "License");
* you may not use this file except in compliance with the License.
*
* You may obtain a copy of the License at
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameProgramValueManager : MonoBehaviour {

    public enum ENUM_GAMEVALUE {
        K_NONE = 0,
        K_COIN,
        K_ENEMY_COUNT
    }

    //Timer Object Settings
    [SerializeField] private ProgramValueElement m_timeCountdown = new ProgramValueElement(0, 300, 0, 300, 0, 300);

    //Game
    [SerializeField] private ProgramValueElement m_playerLife = new ProgramValueElement(0, 3, 0, 3, 0, 3);
    [SerializeField] private ProgramValueElement m_enemyCount = new ProgramValueElement(0, 0, 0, 10000, 0, 100000);

    //Monetization
    [SerializeField] private ProgramValue m_coinEarn = new ProgramValue(0, 0, 0, 1000, 0, 10000);
    [SerializeField] private ProgramValueElement m_coin = new ProgramValueElement(0, 0, 0, 10000, 0, 100000);    

    public GameProgramValueManager Set_TimeCountdown(float _value) { 
        m_timeCountdown.Set_Value(_value);
        return this;
    }
    public GameProgramValueManager Set_PlayerLife(float _value) { 
        m_playerLife.Set_Value(_value);
        return this;
    }

    public float GetValue_CoinEarn() { return m_coinEarn.Get_Value(); }
    public void Increase_CoinEarn(float _value) => m_coinEarn.Set_Value(m_coin.Get_Value() + _value);
    public void Decrease_CoinEarn(float _value) => m_coinEarn.Set_Value(m_coin.Get_Value() - _value);
    public void Increase_Coin(float _value) => m_coin.Set_Value(m_coin.Get_Value() + _value);
    public void Decrease_Coin(float _value) => m_coin.Set_Value(m_coin.Get_Value() - _value);
    public void Increase_EnemyCount(float _value) => m_enemyCount.Set_Value(m_enemyCount.Get_Value() + _value);
}