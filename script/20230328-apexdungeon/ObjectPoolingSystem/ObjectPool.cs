using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

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

    public GameObject GetObject(GameObject obj)
    {
        if(objectPool.TryGetValue(obj.name, out Queue<GameObject> objectList))
        {
            if(objectList.Count == 0)
            {
                return CreateNewObject(obj);

            }
            
            GameObject getObject = objectList.Dequeue();
            getObject.SetActive(true);
            return getObject;
        }

        return CreateNewObject(obj);
    }


    private GameObject CreateNewObject(GameObject obj)
    {
        GameObject newObject = Instantiate(obj);
        newObject.name = obj.name;
        return newObject;
    }

    public void ReturnGameObject(GameObject gameObject)
    {
        if(objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else{
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, newObjectQueue);
        }
        gameObject.SetActive(false);
    }
}
