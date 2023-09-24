using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapon modifier/Stat modifier")]
public class WeaponStatModifier : BaseModifier
{
    [SerializeField] private List<ModifierBoost> modifierBoosts;

    public List<ModifierBoost> ModifierBoosts => modifierBoosts;
}

[System.Serializable]
public class ModifierBoost
{
    public Stats typeToBoost;
    public float valueToBoost;
    public ModifierBoostType modifierBoostType;
}

public enum ModifierBoostType
{
    Add,
    DirectSet
}


