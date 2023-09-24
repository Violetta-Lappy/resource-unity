using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe/Create a Recipe")]
public class Recipe : ScriptableObject
{
    public INGREDIENT_TYPE[] _ingredientType;
    public int[] amount;
    public GameObject outputRecipe;
}
