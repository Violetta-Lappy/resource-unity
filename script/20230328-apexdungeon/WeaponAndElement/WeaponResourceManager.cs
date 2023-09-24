using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponResourceManager : MonoBehaviour
{
    public static WeaponResourceManager instance;

    [SerializeField] private Slider ammoCapSlider;
    [SerializeField] private Slider currentAmmoSlider;

    public BaseGun02[] weaponRefs;
    public float currentResourceCost;
    public float maxResource;
    

    private int weaponIndex = 0;
    public float resourcePerWeapon
    {
        get { return maxResource / 2; }
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        GetWeaponByIndex(weaponIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {   
            //either return 0 or 1
            weaponIndex = (weaponIndex + 1) % 2;
            GetWeaponByIndex(weaponIndex);
        }
    }

    public void OnWeaponShoot()
    {

        for (int i = 0; i < weaponRefs.Length; i++)
        {
            if(i != weaponIndex)
            {
                weaponRefs[i].AddBulletResource(currentResourceCost);
            }
        }

        //Debug.Log(weaponRefs[weaponIndex].bulletsLeft);

        currentAmmoSlider.value = weaponRefs[weaponIndex].bulletsLeft / maxResource;
    }
    
    void GetWeaponByIndex(int index)
    {
        for (int i = 0; i < weaponRefs.Length; i++)
        {
            if (i == index)
            {
                weaponRefs[i].gameObject.SetActive(true);
                currentResourceCost = weaponRefs[i].stats.resourcePerBullet;
            }
            else
            {
                weaponRefs[i].gameObject.SetActive(false);
            }
        }

        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        ammoCapSlider.value = currentResourceCost / maxResource;
        currentAmmoSlider.value = weaponRefs[weaponIndex].bulletsLeft / maxResource;
    }
}
