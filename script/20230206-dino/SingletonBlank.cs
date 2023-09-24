using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBlank<T> : UnityEngine.MonoBehaviour where T : UnityEngine.MonoBehaviour
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)FindObjectOfType(typeof(T));
            SingletonAwake();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void SingletonAwake() { }
}
