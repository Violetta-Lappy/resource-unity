using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomClearedNotification : MonoBehaviour
{
    public static RoomClearedNotification instance;

    private RectTransform rect;
    private Vector2 defaultPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        defaultPosition = rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PushNotification();    
        }
    }

    public void PushNotification()
    {
        //Debug.Log("kekeke");
        rect.DOAnchorPos(new Vector2(0, 260) , .5f).OnComplete(() => StartCoroutine(ReturnRoutine()));
    }

    IEnumerator ReturnRoutine()
    {
        yield return new WaitForSeconds(1.4f);
        rect.DOAnchorPos(defaultPosition, .5f);
    }
}
