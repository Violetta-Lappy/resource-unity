using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : MonoBehaviour
{
    public new string abilityName;

    public float coolDownTime; //time to cool down
    private float currentCoolDownTime=0; //current cool down time

    public float acticeTime; // time to activate
    private float currentActiceTime; // current active time

    public KeyCode key; //key to ativate ability

    //stages
    enum AbilityStage
    {
        ready,
        active,
        cooldown
    }

    //set the state
    AbilityStage state = AbilityStage.ready;

    //Activate function
    public virtual void Activate(GameObject parent)
    {

    }

    
    private void Update()
    {
        switch (state)
        {
            case AbilityStage.ready:
                if (Input.GetKeyDown(key))
                {
                    Activate(gameObject);
                    state = AbilityStage.active;
                    currentActiceTime = acticeTime;
                }
                break;

            case AbilityStage.active:
                if (currentActiceTime > 0)
                {
                    currentActiceTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityStage.cooldown;

                    currentCoolDownTime = coolDownTime;
                }
                break;

            case AbilityStage.cooldown:
                if (currentCoolDownTime > 0)
                {
                    currentCoolDownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityStage.ready;
                    currentCoolDownTime = coolDownTime;
                }
                break;

        }
    }
}
