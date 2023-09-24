using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherit to create a single, global accessible instance of a class, available at all times
public class Singleton_Persist<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;

    //Call this from external script
    //Execute all function when this is called
    public static T Instance 
    { 
        get
        {
            //Execute all "get" code upon called by other scripts
            if(_instance == null)
            {
                _instance =  GameObject.FindObjectOfType<T>();

                //What the hell is this for really !?
                //Create a new game object with exact component
                if(_instance == null)
                {
                    var singletonObj = new GameObject();
                    singletonObj.name = typeof(T).ToString();
                    _instance = singletonObj.AddComponent<T>();
                }
            }

            //return that instance to the script call for it
            return _instance;
        }
    }

    //Allow override when needed
    public virtual void Awake()
    {
        //When this object is already a duplicate exists in a same scene, destroy the duplicated
        if(_instance != null)
        {
            // DebugSystem.Message("Duplicate Singleton Object has been found, this is " + _instance.gameObject.name + " currently destroy this one, " + this.gameObject.name, 
            // ENUM_DEBUG_CATALOG.GAMEPLAY_MANAGER, ENUM_DEBUG_TYPE.WARNING);

            Destroy(gameObject);

            //Exit out of the function, not execute below
            return;
        }

        //Get the required component
        _instance = GetComponent<T>();

        //This GameObject will persist across multiple scenes
        DontDestroyOnLoad(gameObject);

        //Exit out of the function, if there is no singleton
        if (_instance == null) return;    

        //Will run following function if not yet
        AwakeSingleton();            
    }

    public virtual void AwakeSingleton()
    {
        // DebugSystem.Message("Inside Singleton Persist, this manager run Awake only once", ENUM_DEBUG_CATALOG.FRAMEWORK_SYSTEM, ENUM_DEBUG_TYPE.WARNING);
    }
}
