/**
 * author: hoanglongplanner
 * date: Jan 2th 2022
 * des: Inherit to create a single, global accessible instance of a class, available at all times
 */

public class SingletonBlank<T> : UnityEngine.MonoBehaviour where T : UnityEngine.MonoBehaviour {
    public static T Instance { get; private set; }

    public virtual void Awake() {
        if (Instance == null) {
            Instance = (T)FindObjectOfType(typeof(T));            
            SingletonAwake(); //run-extension-function
        } else {
            Destroy(gameObject);
        }
    }

    //Extend functionality if needed, must be override manually
    public virtual void SingletonAwake() { }
}
