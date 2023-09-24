using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentAttack : MonoBehaviour {
    public ProgramValue m_damage;

    public void Attack() {
        Debug.Log("Mighty attack has released !!");
    }

    public void Attack_Charge() {
        Debug.Log("Charging Attack !!");
    }
}
