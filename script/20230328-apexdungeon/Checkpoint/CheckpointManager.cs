
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointManager : MonoBehaviour
{
    public Vector3 lastRoom;


    public static CheckpointManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //testing purposes
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

           
        }

    }
}
