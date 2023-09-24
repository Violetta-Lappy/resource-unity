using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string abilityName;
    public float abilityCoolDownTime;
    public float abilityActiceTime;

    public virtual void Active(GameObject parent)
    {

    }

}
