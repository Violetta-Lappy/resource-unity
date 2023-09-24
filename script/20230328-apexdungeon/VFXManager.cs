using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager instance;
    
    public List<VFX> particles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetParticle(VFXType type)
    {
        foreach (var particle in particles)
        {
            if (particle.vfxType == type)
            {
                return particle.particle;
            }
        }
        
        return null;
    }
}

[System.Serializable]
public class VFX
{
    public GameObject particle;
    public VFXType vfxType;
}

public enum VFXType
{
    PoisonImpact,
    FireImpact,
    ElectricImpact,
    WaterImpact
}