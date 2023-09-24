using System.Collections;
using System.Collections.Generic;

//Other Library
using UnityEngine;
using TMPro;

public class CustomWorldPopup : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public float popupLifetime = 0.6f;
    public float minDist = 2f;
    public float maxDist = 3f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;

    void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);

        float direction = Random.rotation.eulerAngles.z;

        iniPos = transform.position;

        float dist = Random.Range(minDist, maxDist);

        targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0f));

        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float fraction = popupLifetime / 2f;

        if (timer > popupLifetime) 
        Destroy(gameObject);

        else if (timer > fraction) 
        tmpro.color = Color.Lerp(tmpro.color, Color.clear, (timer - fraction) / (popupLifetime - fraction));

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / popupLifetime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / popupLifetime));
    }

    public void Setup(string _text, Color color)
    {
        tmpro.text = _text;
        tmpro.color = color;
    }
}
