using UnityEngine;

public class State_Spawn : FSMStateV5
{
    [Header("State Settings")]
    public Transform spawnLocation;
    public GameObject[] objectsToSpawn;
    public float timeToSpawn = 7.0f;
    public bool isSwitchStateAfterSpawn = false;

    public bool bIsSpawnAll = false;

    //Reference variable
    private float timeToSpawn_Default;

    public override void State_StartLogic(FSMStateManager fsmStateManager)
    {
        //Init Stuff
        timeToSpawn_Default = timeToSpawn;

        //Play animation at the start
        fsmStateManager.ChangeToNewAnimation(fsmStateManager.GetAnimationName(startAnimation));
    }

    public override void State_LoopLogic(FSMStateManager fsmStateManager)
    {
        #region ACTIONS
        //This state only spawn objects set by objectsToSpawn
        //Decrease as time went by
        timeToSpawn -= Time.deltaTime;

        //Spawn objects when meet condition
        if (timeToSpawn <= 0.0f)
        {
            //Spawn Objects
            SpawnRandomObject();

            //Reset time
            timeToSpawn = timeToSpawn_Default;

            //Switch to next state if finish spawn once
            if (isSwitchStateAfterSpawn)
            {
                fsmStateManager.TransitionToState(nextState);
            }
        }

        #endregion ACTIONS

        #region CONDITION SWITCH STATE
        //Check condition and transit to next state        
        if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInAttackRange))
        {
            //Change to idle state
            fsmStateManager.TransitionToState(nextState);
        }

        else if (fsmStateManager.CheckSpecificCondition(ENUM_FSM_CONDITION_TYPE.IsPlayerInLOS))
        {
            //Change to idle state
            fsmStateManager.TransitionToState(nextState);
        }

        #endregion CONDITION SWITCH STATE
    }

    public override void State_EndLogic(FSMStateManager fsmStateManager)
    {

    }

    public void SpawnRandomObject()
    {
        GameObject newObj = null;
        if (bIsSpawnAll)
        {
            for(int i = 0; i < objectsToSpawn.Length; i++)
            {
                newObj = Instantiate(objectsToSpawn[i],
                                enemyCore.transform.position,
                                Quaternion.identity);

                newObj.SetActive(true);
            }            
        }
        else if (!bIsSpawnAll)
        {
            newObj = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)],
                                enemyCore.transform.position,
                                Quaternion.identity);

            newObj.SetActive(true);
        }

        //newObj.GetComponent<GeneralHealth>().spawner =  GetComponent<GeneralHealth>().spawner;
    }
}
