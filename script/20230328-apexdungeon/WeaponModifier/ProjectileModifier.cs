using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileModifier : MonoBehaviour
{
    protected ProjectileBehavior _projectileBehavior;

    public void Awake()
    {
        if(_projectileBehavior == null)
        {
            _projectileBehavior = GetComponent<ProjectileBehavior>();
        }
    }

    public abstract void OnAttach();
    public abstract void OnDetach();
}

public enum ProjectileAttachmentTypes
{
    Pierce,
    Ricochet,
    Explode
}
