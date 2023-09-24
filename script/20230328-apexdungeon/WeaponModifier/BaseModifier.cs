using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseModifier : ItemInventory
{
}


public enum Stats
{
    TimeBtwShooting,
    Spread,
    TimeBtwShots,
    BulletPerShot,
    ResourceBullet,
}