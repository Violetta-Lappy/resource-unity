using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbilityBase
{
    public float dashVeloc = 30f;

    public override void Activate(GameObject parent)
    {
        MoveClone playerMovement = parent.GetComponent<MoveClone>();
        GeneralHealth playerHealth = parent.GetComponent<GeneralHealth>();

        Rigidbody rigid = parent.GetComponent<Rigidbody>();

        rigid.velocity = playerMovement.lastMoveDirection.normalized * dashVeloc;
        playerHealth.Flash();

        Debug.Log("recieved");
    }
}
