using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GunStats", menuName = "GunStats")]
public class GunStats : ScriptableObject
{
    [Tooltip("Fire rate")]
    public float timeBetweenShooting;
    public float spread;
    public float timeBetweenBurst;
    public float bulletPerShot;
    public float resourcePerBullet;
    public bool allowButtonHold = true;

    [Tooltip("This is the distance when the gun reach the max spread")] 
    public float hitEndDistance = 5;

    [Header("Projectile information")]
    public float bulletSpeed;
    public float bulletDamage;
}






