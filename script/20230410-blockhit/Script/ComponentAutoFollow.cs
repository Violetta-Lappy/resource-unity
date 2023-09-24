using UnityEngine;

public class ComponentAutoFollow : UnityEngine.MonoBehaviour {

    [SerializeField] private UnityEngine.Transform m_destination;
    [SerializeField] private UnityEngine.Vector3 m_newDestination;
    [SerializeField] private float f_offsetY = 40.0f;
    [SerializeField] private float f_timeToComplete = 10.0f;
    [SerializeField] private bool isRunMoveFunction = false;

    private void Start() {
        m_newDestination = new Vector3(0, m_destination.position.y - f_offsetY, 0);
        Move(m_newDestination, f_timeToComplete); 
    }
    private void FixedUpdate() {
        m_newDestination = new Vector3(0, m_destination.position.y - f_offsetY, 0);

        if (UnityEngine.Vector3.Distance(this.transform.position, m_destination.position) > 0.01f) {
            if (isRunMoveFunction == false) {
                isRunMoveFunction = true;
                Move(m_newDestination, f_timeToComplete); 
            }
        }
    }

    public void Move(UnityEngine.Vector3 _destination, float _time) => StartCoroutine(RoutineMove(_destination, _time));

    public System.Collections.IEnumerator RoutineMove(UnityEngine.Vector3 _destination, float _time) {

        UnityEngine.Vector3 startPosition = this.transform.position;
        
        bool isReachDest = false;

        float elapsedTime = 0f;

        //While loop for lerp between two destinations purpose
        while (isReachDest == false) {

            if (UnityEngine.Vector3.Distance(this.transform.position, _destination) < 0.01f) {
                isRunMoveFunction = false; //disable-move-status
                isReachDest = true; //confirm
                this.transform.position = _destination; //set the position of this object equals to the destination                

                break; //break-out-of-the-loop                
            }

            //Lerp between 0 and 1
            elapsedTime += UnityEngine.Time.deltaTime;
            float t = elapsedTime / _time;
            this.transform.position = UnityEngine.Vector3.Lerp(startPosition, _destination, t);
            yield return null; //Back to the start of while loop
        }
    }
}
