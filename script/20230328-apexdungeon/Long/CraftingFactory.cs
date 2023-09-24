/*
 AUTHOR: BUI CHAU HOANG LONG
 DATE: 10/10/2021
 SUMMARY: Check the input and then output the correct stuff
 */

#define DEBUG_MODE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingFactory : MonoBehaviour
{
    [Header("Crafting Factory")]
    public Transform spawnLocation;    
    public Recipe _recipe;
    public bool[] recipeChecklist;

    [Header("Factory Recipe [DEBUG ONLY]")]
    public INGREDIENT_TYPE[] _ingredientType;
    public int[] factoryAmount;   
    public GameObject outputRecipe;

    void Start()
    {                
        //Setup the recipe
        _ingredientType = _recipe._ingredientType;

        factoryAmount = new int[_recipe.amount.Length];
        for (int i = 0; i < _recipe.amount.Length; i++)
        {
            factoryAmount[i] = _recipe.amount[i];
        }

        outputRecipe = _recipe.outputRecipe;        

        //Set all item in Checklist to false
        recipeChecklist = new bool[_ingredientType.Length];
        for(int i = 0; i < recipeChecklist.Length; i++)
        {
            recipeChecklist[i] = false;
        }
    }
    
    void Update()
    {
        
    }    

    //Already set it in Start()
    //void SetupFactoryRecipe()
    //{        
    //    _ingredientType = _recipe._ingredientType;
    //    amount = _recipe.amount;
    //    outputRecipe = _recipe.outputRecipe;
    //}

    void ResetFactoryRecipe()
    {        
        for (int i = 0; i < _recipe.amount.Length; i++)
        {
            factoryAmount[i] = _recipe.amount[i];
        }

        for (int i = 0; i < recipeChecklist.Length; i++)
        {
            recipeChecklist[i] = false;
        }

#if DEBUG_MODE == true
        Debug.Log("Reset Factory Recipe !!");
#endif

    }

    public void InputRecipe(GameObject _gameObject)
    {
        //Checking the item is the correct ingredient
        for(int i = 0; i < _ingredientType.Length; i++)
        {
            //Check the correct ingredient
            if(_gameObject.GetComponent<Ingredient>()._ingredientType == _ingredientType[i] && factoryAmount[i] > 0)
            {
                //Decrease that ingredient amount
                factoryAmount[i]--;
                
                if(factoryAmount[i] <= 0)
                {                                        
                    //That ingredient is done
                    recipeChecklist[i] = true;

                    CheckRecipe();
                }

#if DEBUG_MODE == true
                Debug.Log(_gameObject.name + " " + factoryAmount[i]);
#endif

                //Destroy this game object after finish
                Destroy(_gameObject);
            }

            //When full
            else if (_gameObject.GetComponent<Ingredient>()._ingredientType == _ingredientType[i] && factoryAmount[i] <= 0)
            {

#if DEBUG_MODE == true
                Debug.Log("Already have that ingredient, don't need it");
#endif

            }            
        }
    }            

    void CheckRecipe()
    {
        //Check recipe requirement
        bool isRecipeComplete = false;
        int remain = recipeChecklist.Length;

        for (int j = 0; j < recipeChecklist.Length; j++)
        {
            if (recipeChecklist[j] == true)
            {
                remain--;

                if (remain == 0)
                    isRecipeComplete = true;

                if (isRecipeComplete == true)
                {
                    OutputRecipe();

                    //Reset back to default
                    isRecipeComplete = false;
                }
            }
        }
    }

    void OutputRecipe()
    {
        //Output the correct stuff of the recipe, outside the world
        GameObject outputObject = Instantiate(outputRecipe, spawnLocation.position, Quaternion.identity);

#if DEBUG_MODE == true
        Debug.Log("Successfully make that item");
#endif

        ResetFactoryRecipe();
    }    
}
