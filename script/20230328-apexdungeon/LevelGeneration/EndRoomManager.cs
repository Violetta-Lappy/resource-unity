using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomManager : MonoBehaviour
{
    public EnemyHealth theDeath;
    
    public DoorBlockTrigger[] triggers;
    public bool enterRoom = false;
    private void Start()
    {
        triggers = transform.parent.GetComponentsInChildren<DoorBlockTrigger>();
    }

    /// <summary>
    /// Lock room
    /// </summary>
    private void LockRoom()
    {
        if (enterRoom) return;

        enterRoom = true;
        foreach (var trigger in triggers)
        {
            trigger.EnableBlock();
        }
    }
    
    public void SpawnBoss()
    {
        LockRoom();
        var boss = Instantiate(theDeath, transform.position, Quaternion.identity);
        boss.endRoomManager = this;
    }

    public void RegisterKill()
    {
        //MasterGameSystem.Instance.winPanel.SetActive(true);
        //Time.timeScale = 0;

        MasterGameSystem.Instance.Annouce_GameEnd(ENUM_GAME_END_TYPE.WIN);
    }
}
