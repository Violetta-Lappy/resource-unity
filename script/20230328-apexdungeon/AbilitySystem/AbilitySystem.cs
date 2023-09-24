using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    private float coolDownTime;
    private float activeTime;
    public Ability ability;
   // public Ability[] ability;
    public KeyCode key;


    enum AbilityStage
    {
        ready,
        active,
        cooldown
    }

    //set the state
    AbilityStage state = AbilityStage.active;

    // Update is called once per frame
    void Update()
    {
        /*
        foreach (Ability ab in ability)
        {
            if(ab.abilityName = )
        }
        */

        switch (state)
        {
            case AbilityStage.ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Active(gameObject);
                    state = AbilityStage.active;
                    activeTime = ability.abilityActiceTime;
                }
                break;

            case AbilityStage.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                } else
                {
                    state = AbilityStage.cooldown;
                    coolDownTime = ability.abilityCoolDownTime;
                }
                break;

            case AbilityStage.cooldown:
                if (coolDownTime > 0)
                {
                    coolDownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityStage.ready;
                }
                break;

        }
    }
}
