
using UnityEngine;

public class CheckpointReload : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CheckpointManager.Instance.lastRoom = transform.position;
            Debug.Log("Player exited room" + name);
        }
    }


}
