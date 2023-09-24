using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehavior : MonoBehaviour
{
    [Header("Bullet stats")]
    public int collisionCounter = 1;
    public float bulletSpeed; //Bullets' moving speed
    public Vector3 moveDir;
    public float damage;
    public Status dealerStatus = Status.None;
    public PlayerHealth dealerHealth;
    public GameObject waterProjectile, electricProjectile, fireProjectile, natureProjectile;

    private int _currentCollisionCounter;

    [Header("Attachments")]
    public Dictionary<ProjectileAttachmentTypes, ProjectileModifier> projectileAttachments = new Dictionary<ProjectileAttachmentTypes, ProjectileModifier>();


    void AttachmentInit()
    {
        AddAttachmentToDict<PiercingProjectile>(ProjectileAttachmentTypes.Pierce);

        ////Since handling attachment active state is based on the main gun, when the projectile is initially created,
        ////set it to the default state by disabling all the attachment script
        //foreach (var attachments in projectileAttachments.Values)
        //{
        //    attachments.enabled = false;
        //}
    }

    void AddAttachmentToDict<T>(ProjectileAttachmentTypes modifierType) where T : ProjectileModifier
    {
        if (!projectileAttachments.ContainsKey(modifierType))
        {
            projectileAttachments.Add(modifierType, GetComponent<T>());
        }
    }

    public void OnEquipAttachment(ProjectileAttachmentTypes whatAttachment)
    {
        projectileAttachments[whatAttachment].OnAttach();
    }

    //Set rotation and make the bullet move forward
    //Called when the bullet is get from the pool in the weapon script
    public virtual void OnCreated()
    {
        AttachmentInit();
        _currentCollisionCounter = 1;
        Rigidbody bullet = GetComponent<Rigidbody>();
        bullet.velocity = moveDir * bulletSpeed;
        StartCoroutine(SelfDestroy());
    }

    public void ResetCollisionCounter()
    {
        _currentCollisionCounter = collisionCounter;
    }
    
    //Destroy game object after 5s
    //Called in Update()
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5);

        switch (dealerStatus)
        {
            case Status.Fire:
                fireProjectile.GetComponent<ParticleSystem>().Stop(true);
                break;
            case Status.Water:
                waterProjectile.GetComponent<ParticleSystem>().Stop(true);

                break;
            case Status.Poison:
                natureProjectile.GetComponent<ParticleSystem>().Stop(true);

                break;
            case Status.Electric:
                electricProjectile.GetComponent<ParticleSystem>().Stop(true);

                break;
            case Status.None:
                break;
            default:
                break;
        }

        ObjectPool.instance.ReturnGameObject(gameObject);
    }

    //Check to see if it hit player
    //Apply damage
    private void OnTriggerEnter(Collider col)
    {
        EnemyHealth healthRef = col.GetComponent<EnemyHealth>();
        
        //Convert all of this to general health, this part is only for passing bullet dealer status to the health script
        
        if (healthRef!= null && !col.gameObject.CompareTag("Player"))
        {   
            healthRef.TakeDamage(damage, dealerStatus, dealerHealth);            
        }

        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Projectile"))
        {
            ProjectileCollide();
        }
    }

    private void ProjectileCollide()
    {
        switch (dealerStatus)
        {
            case Status.Fire:
                //fireProjectile.GetComponent<ParticleSystem>().Stop(true);
                Instantiate(VFXManager.instance.GetParticle(VFXType.FireImpact), transform.position,
                    Quaternion.identity);
                break;
            case Status.Water:
                //waterProjectile.GetComponent<ParticleSystem>().Stop(true);
                Instantiate(VFXManager.instance.GetParticle(VFXType.WaterImpact), transform.position,
                    Quaternion.identity);
                break;
            case Status.Poison:
                //natureProjectile.GetComponent<ParticleSystem>().Stop(true);
                Instantiate(VFXManager.instance.GetParticle(VFXType.PoisonImpact), transform.position,
                    Quaternion.identity);
                break;
            case Status.Electric:
                //electricProjectile.GetComponent<ParticleSystem>().Stop(true);
                Instantiate(VFXManager.instance.GetParticle(VFXType.ElectricImpact), transform.position,
                    Quaternion.identity);
                break;
            case Status.None:
                break;
        }
        
        _currentCollisionCounter--;

        if (_currentCollisionCounter <= 0)
        {
            ObjectPool.instance.ReturnGameObject(gameObject);
        }
    }
}
