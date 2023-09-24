using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public CinemachineBrain mainCam;
    public CinemachineVirtualCamera frame01Cam;
    public CinemachineVirtualCamera frame02Cam;

    public GameObject[] frame;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangingCam();

        /*if (Input.anyKeyDown && frame[0].activeInHierarchy)
        {
            frame[0].SetActive(false);
            frame[1].SetActive(true);
            frame01Cam.gameObject.SetActive(false);
            frame02Cam.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !frame[0].activeInHierarchy)
        {
            frame[1].SetActive(false);
            frame[2].SetActive(false);
            frame[0].SetActive(true);
            frame01Cam.gameObject.SetActive(true);
            frame02Cam.gameObject.SetActive(false);
        }*/
    }

    private void ChangingCam()
    {
        if (Input.GetKeyDown(KeyCode.Space) && frame[0].activeInHierarchy)
        {
            frame[0].SetActive(false);
            StartCoroutine("Frame2");
            frame01Cam.gameObject.SetActive(false);
            frame02Cam.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && !frame[0].activeInHierarchy)
        {
            frame[1].SetActive(false);
            StartCoroutine("Frame1");
            frame01Cam.gameObject.SetActive(true);
            frame02Cam.gameObject.SetActive(false);
        }
    }

    IEnumerator Frame2()
    {
        yield return new WaitForSeconds(delayTime);
        frame[1].SetActive(true);
    }

    IEnumerator Frame1()
    {
        yield return new WaitForSeconds(delayTime);
        frame[0].SetActive(true);
    }
}
