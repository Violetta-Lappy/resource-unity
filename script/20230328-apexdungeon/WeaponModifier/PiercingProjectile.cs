using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PiercingProjectile : ProjectileModifier
{
    private int _defautlCollisionCount;
    [SerializeField] private int numOfCollision = 3;

    public override void OnAttach()
    {
        Debug.Log("behavior of the piercing projectile");
        _defautlCollisionCount = _projectileBehavior.collisionCounter;
        _projectileBehavior.collisionCounter = numOfCollision;
        _projectileBehavior.ResetCollisionCounter();
    }

    public override void OnDetach()
    {
        _projectileBehavior.collisionCounter = _defautlCollisionCount;
        _projectileBehavior.ResetCollisionCounter();
    }
}
