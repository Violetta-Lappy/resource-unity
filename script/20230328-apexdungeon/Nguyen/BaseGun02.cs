using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*****************************************************************************************************************************
Author: DUONG DUC NGUYEN
Date Made: 08/11/2021
Object(s) holding this script: BaseGun02
Summary: 

*****************************************************************************************************************************/

public class BaseGun02 : MonoBehaviour
{
    public GunStats stats;
    public Transform firingPoint; //Spawning bullet position
    public GameObject bullet;
    public Animator playerAnimator;

    public float bulletsLeft;

    [Header("Elemental reaction")]
    public Status dealerStatus = Status.None;
    public PlayerHealth dealerHealthRef;

    [Header("Weapon modifiers")] 
    [SerializeField] private List<BaseModifier> modifiers;
    public ProjectileAttachmentTypes[] projectileAttachments;

    private int minimumRequiredResource;

    bool shooting, readyToShoot;

    private Dictionary<Stats, float> modifiersBoostValue;

    private Status defaultStatus;
    private void Start()
    {
        //Initialize modifier boost value
        modifiersBoostValue = new Dictionary<Stats, float>()
        {
            {Stats.TimeBtwShooting, 0},
            {Stats.Spread, 0},
            {Stats.TimeBtwShots, 0},
            {Stats.BulletPerShot, 0},
            {Stats.ResourceBullet, 0},
        };       
    
        bulletsLeft = WeaponResourceManager.instance.maxResource / 2;
        
        readyToShoot = true;
        dealerHealthRef = GetComponentInParent<PlayerHealth>();

        defaultStatus = dealerStatus;
    }

    #region Stat boost
    private float GetStat(float baseValue, Stats stat)
    {
        float finalValue = baseValue;

        float boost = modifiersBoostValue[stat];
        
        //The apply modifier is not empty/no
        if (boost != 0)
        { 
            finalValue = baseValue + boost;
        }
        return finalValue;
    }

    private void ApplyBoost(WeaponStatModifier modifier)
    {
        foreach (var boost in modifier.ModifierBoosts)
        {
            var statType = boost.typeToBoost;
            var boostValue = boost.valueToBoost;
            //var modifierType = boost.modifierBoostType;

            modifiersBoostValue[statType] = modifiersBoostValue[statType] + boostValue;


            //switch (modifierType)
            //{
            //    case ModifierBoostType.Add:
            //        modifiersBoostValue[statType] = modifiersBoostValue[statType] + boostValue;
            //        break;
            //    case ModifierBoostType.DirectSet:
            //        modifiersBoostValue[statType] =
            //            modifiersBoostValue[statType] + (boostValue - modifiersBoostValue[statType]);
            //        break;
            //}
                        
        }
    }

    private void RemoveApply(WeaponStatModifier modifier)
    {
        foreach (var boost in modifier.ModifierBoosts)
        {
            var statType = boost.typeToBoost;
            var boostValue = boost.valueToBoost;
            //var modifierType = boost.modifierBoostType;

            modifiersBoostValue[statType] = modifiersBoostValue[statType] - boostValue;

            //switch (modifierType)
            //{
            //    case ModifierBoostType.Add:
            //        modifiersBoostValue[statType] = modifiersBoostValue[statType] - boostValue;
            //        break;
            //    case ModifierBoostType.DirectSet:


            //        modifiersBoostValue[statType] =
            //            modifiersBoostValue[statType] - (boostValue + modifiersBoostValue[statType]);

                   
            //        break;
            //}

            //Debug.Log("After " + modifiersBoostValue[statType]);

        }
    }

    public void AddMod(WeaponStatModifier mod)
    {
        if (!modifiers.Contains(mod))
        {
            //Debug.Log("Stat equiped");
            modifiers.Add(mod);
            ApplyBoost(mod);
        }
    }

    public void RemoveMod(WeaponStatModifier mod)
    {
        if (modifiers.Contains(mod))
        {
            //Debug.Log("Stat removed");
            modifiers.Remove(mod);
            RemoveApply(mod);
        }
    }

    public void ChangeStatus(ElementalModifier modifier)
    {
        dealerStatus = modifier.status;
    }

    public void RemoveStatus()
    {
        dealerStatus = defaultStatus;
    }

    #endregion

    private void Update()
    {
        GetInput();
    }
    
    
    //Called in Update()
    private void GetInput()
    {
        //dont fire this gun when no resource left
        if (bulletsLeft < stats.resourcePerBullet) return;

        if (stats.allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (shooting && readyToShoot)
        {
            //bulletsShot = stats.bulletPerTap;

            //bulletsShot = GetStat(stats.bulletPerShot, Stats.BulletPerShot);
            Shoot();
            StartCoroutine(ShootCooldown());
        }
    }
    
    private void Shoot()
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_TYPE.GUN);
        }        

        float offsetValue = 0f;
        float spreadAngle = GetStat(stats.spread, Stats.Spread);
        //using mathf max and pass a variable of 1 so that 
        for (int i = 0; i < Mathf.Max(1, GetStat(stats.bulletPerShot, Stats.BulletPerShot)); i++)
        {
            offsetValue = (i  - (GetStat(stats.bulletPerShot, Stats.BulletPerShot) - 1) / 2) * spreadAngle; //what is this?
            InitializeProjectile(offsetValue);
        }
    }

    private void InitializeProjectile(float offset)
    {
        var spawnPosition = firingPoint.position;

        //GameObject projectile = Instantiate(bullet, spawnPosition,Quaternion.identity);

        GameObject projectile = ObjectPool.instance.GetObject(bullet);
        projectile.transform.position = spawnPosition;
        projectile.transform.rotation = Quaternion.identity;

        ProjectileBehavior playerProjectileBehavior = projectile.GetComponent<ProjectileBehavior>();

        //Spread
        Vector3 hitEnd = spawnPosition + firingPoint.forward * stats.hitEndDistance;
        //hitEnd += Random.Range(-GetStat(stats.spread, Stats.Spread), GetStat(stats.spread, Stats.Spread)) * firingPoint.right;
        //var mid = (int)bulletsShot / 2;

        //for (int i = -mid; i <= mid; i++)
        //{
        //    hitEnd += i * firingPoint.right * 90;

        //    Debug.Log(hitEnd);

        //}

        Vector3 bulletDirection = (hitEnd - spawnPosition).normalized;

        bulletDirection = Quaternion.AngleAxis(offset, Vector3.up) * bulletDirection;

        Debug.DrawRay(spawnPosition, bulletDirection * 10f, Color.yellow, 10f);

        Vector3 right = Vector3.Cross(bulletDirection, Vector3.up).normalized;

        // projectile.transform.LookAt(bulletDirection);
        projectile.transform.rotation = Quaternion.AngleAxis(90, right);

        if (dealerHealthRef != null)
        {
            playerProjectileBehavior.dealerHealth = dealerHealthRef;
        }

        playerProjectileBehavior.bulletSpeed = stats.bulletSpeed;
        playerProjectileBehavior.damage = stats.bulletDamage;
        playerProjectileBehavior.moveDir = bulletDirection;
        playerProjectileBehavior.dealerStatus = dealerStatus;

        
        switch (dealerStatus)
        {
            case Status.Fire:
                playerProjectileBehavior.fireProjectile.SetActive(true);
                playerProjectileBehavior.waterProjectile.SetActive(false);
                playerProjectileBehavior.natureProjectile.SetActive(false);
                playerProjectileBehavior.electricProjectile.SetActive(false);

                playerProjectileBehavior.fireProjectile.GetComponent<ParticleSystem>().Simulate(1,true);
                playerProjectileBehavior.fireProjectile.GetComponent<ParticleSystem>().Play(true);

                break;
            case Status.Water:
                playerProjectileBehavior.fireProjectile.SetActive(false);
                playerProjectileBehavior.waterProjectile.SetActive(true);
                playerProjectileBehavior.natureProjectile.SetActive(false);
                playerProjectileBehavior.electricProjectile.SetActive(false);

                playerProjectileBehavior.waterProjectile.GetComponent<ParticleSystem>().Simulate(1, true);
                playerProjectileBehavior.waterProjectile.GetComponent<ParticleSystem>().Play(true);
                break;
            case Status.Poison:
                playerProjectileBehavior.fireProjectile.SetActive(false);
                playerProjectileBehavior.waterProjectile.SetActive(false);
                playerProjectileBehavior.natureProjectile.SetActive(true);
                playerProjectileBehavior.electricProjectile.SetActive(false);

                playerProjectileBehavior.natureProjectile.GetComponent<ParticleSystem>().Simulate(1, true);
                playerProjectileBehavior.natureProjectile.GetComponent<ParticleSystem>().Play(true);
                break;
            case Status.Electric:
                playerProjectileBehavior.fireProjectile.SetActive(false);
                playerProjectileBehavior.waterProjectile.SetActive(false);
                playerProjectileBehavior.natureProjectile.SetActive(false);
                playerProjectileBehavior.electricProjectile.SetActive(true);

                playerProjectileBehavior.electricProjectile.GetComponent<ParticleSystem>().Simulate(1, true);
                playerProjectileBehavior.electricProjectile.GetComponent<ParticleSystem>().Play(true);
                break;
            case Status.None:
                break;
            default:
                break;
        }
        

        //Must be called first before adding the attachment so that the attachment is initialized
        playerProjectileBehavior.OnCreated();

        //Applying the projectile attachment method
        foreach (var a in projectileAttachments)
        {
            playerProjectileBehavior.OnEquipAttachment(a);
        }

        bulletsLeft -= stats.resourcePerBullet;
        bulletsLeft = Mathf.Clamp(bulletsLeft, 0, WeaponResourceManager.instance.maxResource);

        WeaponResourceManager.instance.OnWeaponShoot();

        CinemachineCameraController.instance.ScreenShake(5, .1f, .3f);
    }

    ////Called by GetInput()
    //private void Shoot()
    //{
    //    readyToShoot = false;

    //    var spawnPosition = firingPoint.position;

    //    //GameObject projectile = Instantiate(bullet, spawnPosition,Quaternion.identity);

    //    GameObject projectile = ObjectPool.instance.GetObject(bullet);
    //    projectile.transform.position = spawnPosition;
    //    projectile.transform.rotation = Quaternion.identity;

    //    ProjectileBehavior playerProjectileBehavior = projectile.GetComponent<ProjectileBehavior>();

    //    //Spread
    //    Vector3 hitEnd = spawnPosition + firingPoint.forward * stats.hitEndDistance;
    //    //hitEnd += Random.Range(-GetStat(stats.spread, Stats.Spread), GetStat(stats.spread, Stats.Spread)) * firingPoint.right;
    //    var mid = (int)bulletsShot / 2;

    //    for (int i = -mid ; i <= mid; i++)
    //    {
    //        hitEnd += i * firingPoint.right * 90;

    //        Debug.Log(hitEnd);

    //    }

    //    Vector3 bulletDirection = (hitEnd - spawnPosition).normalized;

    //    Vector3 right = Vector3.Cross(bulletDirection, Vector3.up).normalized;

    //    // projectile.transform.LookAt(bulletDirection);
    //    projectile.transform.rotation = Quaternion.AngleAxis(90, right);

    //    if (dealerHealthRef != null)
    //    {
    //        playerProjectileBehavior.dealerHealth = dealerHealthRef;
    //    }

    //    playerProjectileBehavior.bulletSpeed = stats.bulletSpeed;
    //    playerProjectileBehavior.damage = stats.bulletDamage;
    //    playerProjectileBehavior.moveDir = bulletDirection;
    //    playerProjectileBehavior.dealerStatus = dealerStatus;

    //    //Must be called first before adding the attachment so that the attachment is initialized
    //    playerProjectileBehavior.OnCreated();

    //    //Applying the projectile attachment method
    //    foreach (var a in projectileAttachments)
    //    {
    //        playerProjectileBehavior.OnEquipAttachment(a);
    //    }


    //    WeaponResourceManager.instance.OnWeaponShoot();

    //    bulletsLeft -= stats.resourcePerBullet;
    //    bulletsLeft = Mathf.Clamp(bulletsLeft, 0, WeaponResourceManager.instance.maxResource);
    //    bulletsShot--;

    //    CinemachineCameraController.instance.ScreenShake(5, .1f, .3f);

    //    Invoke(nameof(ResetShoot), GetStat(stats.timeBetweenShooting, Stats.TimeBtwShooting));

    //    //StartCoroutine(ResetShot());


    //    if (bulletsShot > 0 && bulletsLeft > 0)
    //        Invoke(nameof(Shoot), GetStat(stats.timeBetweenShots, Stats.TimeBtwShots));
    //}

    public void AddBulletResource(float valueToAdd)
    {
        bulletsLeft += valueToAdd;
        bulletsLeft = Mathf.Clamp(bulletsLeft, 0, WeaponResourceManager.instance.maxResource);
    }
    
    void ResetShoot()
    {
        readyToShoot = true;
    }
    
    private void OnDisable()
    {
        //StopCoroutine(ResetShot());
        //readyToShoot = true;
        ResetShoot();
    }
    
    IEnumerator ShootCooldown()
    {
        var layerWeight = 0;
        DOTween.To(() => layerWeight, x => layerWeight = x, 1, 0.05f).OnComplete(() => UpdateLayerWeight(layerWeight));

        readyToShoot = false;
        yield return new WaitForSeconds(GetStat(stats.timeBetweenShooting, Stats.TimeBtwShooting));
        DOTween.To(() => layerWeight, x => layerWeight = x, 0, GetStat(stats.timeBetweenShooting, Stats.TimeBtwShooting)).
            OnComplete(() => UpdateLayerWeight(layerWeight));
        readyToShoot = true;
        playerAnimator.SetLayerWeight(1, layerWeight);
    }

    void UpdateLayerWeight(float weight)
    {
        //Debug.Log("Weight is " + weight);
        playerAnimator.SetLayerWeight(1, weight);
    }
}



