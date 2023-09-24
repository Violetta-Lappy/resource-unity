using UnityEngine;

public class ComponentAutoLerpToDestination : UnityEngine.MonoBehaviour {
    
    [SerializeField] private UnityEngine.Transform[] sz_m_destination;
    private int i32_current;
    [SerializeField] private float f_timeToComplete = 10.0f;

    private void Start() => Move(sz_m_destination[0], f_timeToComplete);

    public void Move(UnityEngine.Transform _destination, float _time) => StartCoroutine(RoutineMove(_destination.position, _time));

    public System.Collections.IEnumerator RoutineMove(UnityEngine.Vector3 _destination, float _time) {
        
        UnityEngine.Vector3 startPosition = this.transform.position;
        
        bool isReachDest = false;
        
        float elapsedTime = 0f;

        //While loop for lerp between two destinations purpose
        while (isReachDest == false) {

            if (UnityEngine.Vector3.Distance(this.transform.position, _destination) < 0.01f) {
                isReachDest = true; //confirm
                this.transform.position = _destination; //set the position of this object equals to the destination

                i32_current++;
                if (i32_current >= sz_m_destination.Length) i32_current = 0;

                Move(sz_m_destination[i32_current], f_timeToComplete);

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
