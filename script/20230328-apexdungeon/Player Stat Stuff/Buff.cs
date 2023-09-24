using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BUFF_TYPE
{
    Health,
    Stamina
}

public class Buff : MonoBehaviour
{   
    public BUFF_TYPE buffType;

    [Range(-100, 100)]
    public int value = 2;
    [Range(0.1f, 10.0f)]
    public float duration = 2.0f; 

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag(ProjectConstants.TAG_PLAYER))
        {
            if(buffType == BUFF_TYPE.Health)
            {                
                PlayerStat.Instance.BuffTemporary_Extension(BUFF_TYPE.Health, value, duration);

                Destroy(this.gameObject);
            }
            
            else if(buffType == BUFF_TYPE.Stamina)
            {                
                PlayerStat.Instance.BuffTemporary_Extension(BUFF_TYPE.Stamina, value, duration);

                Destroy(this.gameObject);
            }            
        }               
    }        
}
