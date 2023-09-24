using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DashAbility : Ability
{
    public float dashVeloc = 30f;

    public override void Active(GameObject parent)
    {
        MoveClone playerMovement = parent.GetComponent<MoveClone>();
        GeneralHealth playerHealth = parent.GetComponent<GeneralHealth>();

        Rigidbody rigid = parent.GetComponent<Rigidbody>();

         rigid.velocity = playerMovement.lastMoveDirection.normalized * dashVeloc;
        playerHealth.Flash();

        Debug.Log("recieved");
    }

}
