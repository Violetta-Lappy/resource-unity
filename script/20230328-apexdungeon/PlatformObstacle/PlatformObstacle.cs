#define DEBUG_MODE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public enum PlatformObstacle_TYPE
{
    NONE,
    TRIGGER_MOVE,
    AUTO_MOVE    
}

public enum PlatformObstacle_TRAPTYPE
{
    NONE,
    CRUMBLING,
    SPIKE    
}

public class PlatformObstacle : MonoBehaviour
{
    public PlatformObstacle_TYPE platformObstacleType;
    public PlatformObstacle_TRAPTYPE platformObstacleTrapType;
    public GameObject platform;

    [Header("Platform Settings")]
    public Transform locationA;
    public Transform locationB;
    private bool isCross = false;
    public float duration = 5.0f;
    public Ease easeType = Ease.Linear;
    
    [Header("Trap Setting")]
    public float damage = 20.0f;
    public float trapTime = 5.0f;
    public float trapTimeDefault = 5.0f;
    
    void Start()
    {        
        platform.transform.position = locationA.position;    

        if(platformObstacleType == PlatformObstacle_TYPE.AUTO_MOVE)
            AutoMove();
    }
   
    void Update()
    {
        //For testing purpose
        if(Input.GetKeyDown(KeyCode.T))
            ManualMove();        
    }

    public void AutoMove()
    {        
        Tween tempTween = platform.transform.DOMove(locationB.position, duration);
        Tween tempTween2 = platform.transform.DOMove(locationA.position, duration);

        Sequence doTweenAutoMoveSEQ = DOTween.Sequence();        
        doTweenAutoMoveSEQ.Append(tempTween);
        doTweenAutoMoveSEQ.Append(tempTween2);
        doTweenAutoMoveSEQ.Play().SetEase(easeType).SetLoops(-1);                
    }

    public void ManualMove()
    {
        if(!isCross)
        {                    
            platform.transform.DOMove(locationB.position, duration).SetEase(easeType).SetLoops(0);            
        }

        else if(isCross)
        {
            platform.transform.DOMove(locationA.position, duration).SetEase(easeType).SetLoops(0);                                                
        }   

        isCross = !isCross;                
    }        

    public void ResetTrap_External(float duration = 5.0f)
    {
        StartCoroutine(ResetTrap(duration));
    }

    private IEnumerator ResetTrap(float duration = 5.0f)
    {
        //Reset trap time
        trapTime = trapTimeDefault;

        yield return new WaitForSeconds(duration);

        //Disappear the spike mesh

        if(platformObstacleTrapType == PlatformObstacle_TRAPTYPE.CRUMBLING)
            platform.SetActive(true);
    }
}
