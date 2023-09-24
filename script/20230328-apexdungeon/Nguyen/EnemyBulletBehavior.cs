using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : Bullet01Behavior
{
    public Vector3 bulletDir;
    
    // Start is called before the first frame update
    public override void Start()
    {
        MoveForward();
    }

    public override void MoveForward()
    {
        this.transform.rotation = Quaternion.Euler(90, rotateDir, 0);
    }
}
